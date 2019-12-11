using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingBlock : BasicBlock
{
    public float failingTime;
    public float recoverTime;
    public float fadingDepth = -10;
    private Vector3 recoverDepth;
    public Material failingMaterial;
    private Material recoverMaterial;
    private bool notfading;
    // Start is called before the first frame update

    private void Start()
    {
        recoverMaterial = GetComponent<MeshRenderer>().material;
        recoverDepth = transform.position;
        notfading = true;
    }

    private IEnumerator fadingOut()
    {
        GetComponent<MeshRenderer>().material = failingMaterial;
        yield return new WaitForSeconds(failingTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, fadingDepth);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<MeshRenderer>().material = recoverMaterial;
        yield return new WaitForSeconds(recoverTime);
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = recoverDepth;
        GetComponent<MeshRenderer>().material = recoverMaterial;
        notfading = true;


    }

    protected override void PlayersOn(Collision2D collision)
    {
        //Things happens when players on the block
        if (notfading)
        {
            notfading = false;
             StartCoroutine(fadingOut());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 reswarpP;
    private BoxCollider2D TheZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false; // making sure not have double shoot
            collision.gameObject.transform.position = reswarpP;
            GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}

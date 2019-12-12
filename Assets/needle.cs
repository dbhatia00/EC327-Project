using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
}

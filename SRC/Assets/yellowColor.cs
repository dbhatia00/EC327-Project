using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow; //change color to yellow
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

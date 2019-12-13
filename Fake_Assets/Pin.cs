using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private double damageRate;
    private static bool DoDamage;
    // Start is called before the first frame update


    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().isTrigger = true;

    }
    
}

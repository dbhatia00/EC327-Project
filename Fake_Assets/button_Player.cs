using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class button_Player : MonoBehaviour
{
    public GameObject triger;
    private Collider2D Touch;
    private bool Istouching;
    // Start is called before the first frame update
    private void Update()
    {
        if (GetComponent<Collider2D>().IsTouching(Touch))
            triger.GetComponent<TrigerObject>().Trigered();
        else
            triger.GetComponent<TrigerObject>().UnTrigered();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
            Touch = collision.gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
            Touch = collision.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame

}

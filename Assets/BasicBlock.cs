using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
     //Initialize the basic information, 
     //Corner position
     //orientation
    }

    protected virtual void BulletsOn(Collider2D collision)
    {
        Destroy(collision.gameObject);
        //Things happens when bullets on the block
    }

    protected virtual void BulletsOn(Collision2D collision)
    {
        Destroy(collision.gameObject);
        //Things happens when bullets on the block
    }

    protected virtual void PlayersOn(Collision2D collision)
    {
        //Things happens when players on the block
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayersOn(collision);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletsOn(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletsOn(collision);
        }
    }

 

}

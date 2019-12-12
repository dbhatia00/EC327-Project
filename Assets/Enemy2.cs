using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyObjects
{
    public bool isRight;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        rightEdge = isRight;
    }

    // Update is called once per frame
    void Update()
    {
        
        doFire();
       
    }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    protected override void fire()
    {
        bulletpos = transform.position;

        if (facingRight)
        {
            bulletpos += new Vector2(3f, 0.5f);
            Instantiate(BulletR, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-3f, 0.5f);
            Instantiate(BulletL, bulletpos, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyObjects
{
    // Start is called before the first frame update
    public GameObject BulletRU, BulletLU;
    public CharacterHealth Healthbar;
    void Start()
    {
        //rightEdge = true;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();

        move();

        doFire();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Healthbar.DealDamage(2);
    }

    protected override void move()
    {
        base.move();
    }

    protected override void fire()
    {
        bulletpos = transform.position;


        if (facingRight)
        {
            bulletpos += new Vector2(2f, -0f);
            Instantiate(BulletRU, bulletpos, Quaternion.identity);
            Instantiate(BulletR, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-2f, -0f);
            Instantiate(BulletLU, bulletpos, Quaternion.identity);
            Instantiate(BulletL, bulletpos, Quaternion.identity);
        }
    }

    protected override void checkPosition()
    {
        base.checkPosition();
    }

    protected override void doFire()
    {
        base.doFire();
    }

}

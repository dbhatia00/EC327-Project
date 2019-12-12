using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjects : MonoBehaviour
{
    //this is abstract class

    public GameObject BulletR, BulletL;
    protected Vector2 bulletpos;
    public float fireRate;
    protected float nextFire = 0.0f;
    protected bool rightEdge;
    protected bool facingRight;

    protected Vector2 bpos;
    protected Vector2 startPos;

    public float boxSpeed;
    public float boxRange;

    int count;

    protected virtual void move()
    {
        if (rightEdge == true)
        {
            bpos.x -= boxSpeed*Time.deltaTime;
            facingRight =false;
        }
        else
        {
            bpos.x += boxSpeed*Time.deltaTime;
            facingRight = true;
        }

        this.transform.position = bpos;

    }

    protected virtual void fire()
    {
        bulletpos = transform.position;

        if (facingRight)
        {
            bulletpos += new Vector2(1.4f, -0.2f);
            Instantiate(BulletR, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-1.4f, -0.2f);
            Instantiate(BulletL, bulletpos, Quaternion.identity);
        }
    }

    protected virtual void doFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        count++;
        if (count == 3)
        {
            Destroy(this);

            this.gameObject.SetActive(false);
        }
    }

    protected virtual void checkPosition()
    {

        bpos = this.transform.position;
        if (bpos.x >= startPos.x + boxRange)
        {
            rightEdge = true;
        }
        if (bpos.x <= startPos.x - boxRange)
        {
            rightEdge = false;
        }
    }
}

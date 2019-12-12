using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{


	Rigidbody2D box;
    public GameObject BulletR, BulletL;
    public GameObject BulletRU, BulletLU;
    Vector2 bulletpos;
    Vector2 bulletpos2;
    Vector2 ranPos;
   public const float fireRate = 0.5f;
    float nextFire = 0.0f;
    public  bool facingRight;
    bool rightEdge;
    public Transform Sphere;

    float next;
    int count;

    Vector2 bpos;

    Vector2 startPos;

    //Vector2 BBpox;
    public float boxSpeed;
    public float boxRange;
	//Vector2 bpos = box.position;
	// Start is called before the first frame update
	void Start()
	{
        ranPos = this.transform.position;
        facingRight = false;
        //Debug.Log(yPos);
        rightEdge = true;
        startPos = transform.position;
	}



    // Update is called once per frame

    
    void Update()
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


        /*if (rightEdge == true)
        {

            bpos.x -= boxSpeed;
            this.transform.position = bpos;
            facingRight = false;
        }
        else
        {
            bpos.x += boxSpeed;
            facingRight = true;
        }


    this.transform.position = bpos;*/
            
            move();
        /*transform.LookAt(Sphere);

        if(Vector2.Distance(bpos, Sphere.position) >= 0)
        {
            transform.position += transform.forward * boxSpeed;
        }
        */
        /*if (bpos.y < -10)
        {
            Destroy(gameObject);

        }*/

        //Debug.Log(fireRate);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
            
        }
        
	}

    void wait()
    {

    }
    void move()
    {
        if (rightEdge == true)
        {

            bpos.x -= boxSpeed;
            //this.transform.position = bpos;
            facingRight = false;
        }
        else
        {
            bpos.x += boxSpeed;
            //this.transform.position = bpos;
            facingRight = true;
        }


        this.transform.position = bpos;
    }

    bool flag()
    {
        next = Time.time + 4;

        if (Time.time > next)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bhit");
        count++;
        if (count == 3)
        {
            Destroy(other);

            
            /*int ranb = Random.Range(0, 10) % 2;
            Debug.Log(ranb);
            if (ranb == 1)
            {
                facingRight = true;
            }
            else
            {
                facingRight = false;
            }
            ranPos.x = Random.Range(-8.0f, 8.0f);

            Instantiate(this.gameObject, ranPos, Quaternion.identity);*/
            this.gameObject.SetActive(false);
        }
    }

    void fire()
    {
        bulletpos = transform.position;

        /*bulletpos += new Vector2(1f, -0.2f);

        Instantiate(BulletRU, bulletpos, Quaternion.identity);
        Instantiate(BulletR, bulletpos, Quaternion.identity);

        bulletpos = transform.position;

        bulletpos += new Vector2(-1f, -0.2f);

        Instantiate(BulletLU, bulletpos, Quaternion.identity);
        Instantiate(BulletL, bulletpos, Quaternion.identity);*/
     
        if (facingRight)
        {
            bulletpos += new Vector2(+1f, -0.2f);
            
            Instantiate(BulletR, bulletpos, Quaternion.identity);

            /*if (Time.time >= 10)
            {
                bulletpos = transform.position;
                bulletpos += new Vector2(-2f, -0.2f);
                Instantiate(BulletL, bulletpos, Quaternion.identity);
            }
            if (Time.time >= 20)
            {
                bulletpos = transform.position;
                bulletpos += new Vector2(1f, 0f);
                Instantiate(BulletRU, bulletpos, Quaternion.identity);
                bulletpos = transform.position;
                bulletpos += new Vector2(-1f, 0f);
                Instantiate(BulletLU, bulletpos, Quaternion.identity);
            }*/
        }
        else
        {
            bulletpos += new Vector2(-1f, -0.2f);
            Instantiate(BulletL, bulletpos, Quaternion.identity);

            /*if (Time.time >= 10)
            {
                bulletpos = transform.position;
                bulletpos += new Vector2(2f, -0.2f);
                Instantiate(BulletR, bulletpos, Quaternion.identity);
            }
            if (Time.time >= 20)
            {
                bulletpos = transform.position;
                bulletpos += new Vector2(1f, 0f);
                Instantiate(BulletLU, bulletpos, Quaternion.identity);
                bulletpos = transform.position;
                bulletpos += new Vector2(-1f, 0f);
                Instantiate(BulletRU, bulletpos, Quaternion.identity);
            }*/
        }
    }


}

  
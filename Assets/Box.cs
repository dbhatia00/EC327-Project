using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{


	Rigidbody2D box;
    public GameObject BulletR, BulletL;
    Vector2 bulletpos;
    Vector2 ranPos;
   public const float fireRate = 1f;
    float nextFire = 0.0f;
    public  bool facingRight;
    bool rightEdge;

    //Vector2 BBpox;
    public float boxSpeed;
	//Vector2 bpos = box.position;
	// Start is called before the first frame update
	void Start()
	{
        ranPos = this.transform.position;
        facingRight = false;
        //Debug.Log(yPos);
	}


    

    // Update is called once per frame

    
    void Update()
	{

        Vector2 bpos = this.transform.position;
		if (bpos.x >= 16)
		{
			rightEdge = true;
		}
		if (bpos.x <= -16)
		{
			rightEdge = false;
		}

		if (rightEdge == true)
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
		this.transform.position = bpos;

        if (bpos.y < -10)
        {
            Destroy(gameObject);

        }

        Debug.Log(fireRate);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
            
        }
        
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");

        Destroy(other.gameObject);
        int ranb = Random.Range(0, 10) % 2;
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

        Instantiate(this.gameObject, ranPos, Quaternion.identity);
        this.gameObject.SetActive(false);

    }

    void fire()
    {
        bulletpos = transform.position;

        if (facingRight)
        {
            bulletpos += new Vector2(+1f, -0.2f);
            Instantiate(BulletR, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-1f, -0.2f);
            Instantiate(BulletL, bulletpos, Quaternion.identity);
        }
    }


}


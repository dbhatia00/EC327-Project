using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2d;
    public GameObject BulletR, BulletL;
    Vector2 bulletpos;
    public float fireRate = 0.5f, jumpRate = 0.7f;

    static int count = 0;
    
    float nextFire = 0.0f, nextJump = 0.0f;
    bool facingRight = true;
    public bool isGrounded = false;
    public float playerSpeed;

    public CharacterHealth Healthbar;

    void Start()
    {
        //startPos = transform.position;
    }

    void fire()
    {
        bulletpos = transform.position;
        
        if (facingRight)
        {
            bulletpos += new Vector2(+1.3f, 0.0f);
            Instantiate(BulletR, bulletpos, Quaternion.identity);
        }
        else
        {
            bulletpos += new Vector2(-1.3f, 0.0f);
            Instantiate(BulletL, bulletpos, Quaternion.identity);
        }
    }

    void Update()
    {
        //var move = Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x -= playerSpeed*Time.deltaTime;
            this.transform.position = position;
            facingRight = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x += playerSpeed*Time.deltaTime;
            this.transform.position = position;
            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time>nextJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,10f), ForceMode2D.Impulse);
            nextJump = Time.time + jumpRate;
        }

        if (Input.GetButtonDown("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
            Debug.Log("shot");
        }


        if (transform.position.y < -100)
        {
            Destroy(this);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Healthbar.DealDamage(2);
        /*count++;
        if (count == 3)
        {
            Camera.main.transform.parent = null;
            Destroy(this);
            this.gameObject.SetActive(false);
        }
     
        Debug.Log("hit " + count);*/
    }

}

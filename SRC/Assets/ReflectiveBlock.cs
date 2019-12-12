using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveBlock : BasicBlock
{
    public Object BulletModel;
    private Bullet BulletIn;
    private Vector2 reBulletDir;
    private float reBulletVel;
    private Vector3 reBulletPo;
    private ContactPoint2D[] contactP = new ContactPoint2D[2];
    private Vector2 Vertical;
    private int num_Contact;


    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }


    protected override void BulletsOn(Collision2D collision)
    {
        // find the normal direction to the contact surface

        reBulletDir = Vector2.Reflect(collision.relativeVelocity, collision.contacts[0].normal).normalized; // find the reflective velocity

        reBulletVel = collision.relativeVelocity.magnitude; //Same velocity

        reBulletPo = collision.transform.position; // same position

        Destroy(collision.gameObject);

        GameObject Reflected = (GameObject)Instantiate(BulletModel); //Create the new bullet

        Bullet rigi = Reflected.GetComponent<Bullet>(); //

        rigi.velX = reBulletVel * reBulletDir.x;

        rigi.velY = reBulletVel * reBulletDir.y;

        Reflected.transform.position = reBulletPo + new Vector3(rigi.velX*0.02f, rigi.velY * 0.02f, 0); //create new at the same place


    }


    Bullet converting;


    //==================================================================================
    //This part is create cuz the above code performs well only when the
    //The bullet is nonTriger
    //Just a quick fix, may improve later lol
    protected override void BulletsOn(Collider2D collision)
    {
        converting = collision.GetComponent<Bullet>();
        collision.transform.position -= new Vector3(converting.velX, converting.velY, 0) * 0.02f;
        collision.isTrigger = false;
    }

    protected override void PlayersOn(Collision2D collision)
    {
        //nothing to do with player
    }


}

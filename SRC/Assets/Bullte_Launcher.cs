using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullte_Launcher : TrigerObject
{
    // Start is called before the first frame update
    public Object BulletModel;
    public float launch_po = 2f;
    public bool right;
    public double firerate = 2;
    public float bullet_speed = 3f;
    private double nextfire = 0;
    private Vector3 bullet_po;
    private float bullet_vel;

    // Update is called once per frame
    private void Start()
    {
    
        if (right)
        {
            bullet_po = transform.position + new Vector3(launch_po, 0, 0);
            bullet_vel = bullet_speed;
        }
        else
        {
            bullet_po = transform.position - new Vector3(launch_po, 0, 0);
            bullet_vel = -bullet_speed;
        }
    }
    public override void Trigered()
    {
        if (Time.time > nextfire)
        {
            GameObject bullet = (GameObject)Instantiate(BulletModel); //Create the new bullet
            bullet.transform.position = bullet_po;
            Bullet rigi = bullet.GetComponent<Bullet>();
            rigi.velX = bullet_vel;
            rigi.velY = 0;
            nextfire = Time.time + firerate;
        }
    }
}

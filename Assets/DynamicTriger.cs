using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTriger : TrigerObject
{
    public bool One_Way;
    public bool drift_t_rotate_f;
    public float Drift_speed;
    public float Rotate_speed;
    private Vector3 initial_po;
    public float triggered_angle;
    private Vector3 initial_angle;
    public Vector3 triggered_po;
    private bool state;
    private Vector3 triggered_angle_vec;
    private Vector3 rotate_speed_vec;

    private void Start()
    {
       Drift_speed *= Time.deltaTime*50;
        Rotate_speed *= Time.deltaTime * 50;

    initial_po = transform.position;
        initial_angle = transform.eulerAngles;
        state = false;
        //quick fix on the angle
        triggered_angle_vec = new Vector3(0, 0, triggered_angle);
        rotate_speed_vec = new Vector3(0,0,-Rotate_speed * 0.5f);


    }

    public override void Trigered()
    {
        state = true;
        Debug.Log("hit");
    }
    public override void UnTrigered()
    {
        if(!One_Way)
        state = false;
        Debug.Log("nothit");
    }
    private void Update()
    {
        if (state)
        {
            if (drift_t_rotate_f)
            {

                if (Vector3.Distance(transform.position, triggered_po) <= Drift_speed * 0.01f)
                {
                    transform.position = triggered_po;
                }
                else
                {

                    transform.position += (triggered_po - transform.position).normalized * Drift_speed * 0.01f;
                }
            }

            else
            {
                //quick fix
                if (transform.eulerAngles.z <= triggered_angle+Rotate_speed && transform.eulerAngles.z >= triggered_angle - Rotate_speed)
                {
                    transform.eulerAngles = triggered_angle_vec;
                }
                else
                    transform.eulerAngles += rotate_speed_vec*0.4f;
            }
        }


        else if(!One_Way)
        {
            if (drift_t_rotate_f)
            {

                if (Vector3.Distance(transform.position, initial_po) <= Drift_speed * 0.01f)
                {
                    transform.position = initial_po;
                }
                else
                {

                    transform.position += (initial_po - transform.position).normalized * Drift_speed * 0.01f;
                }
            }

            else
            {
                if (transform.eulerAngles.z < initial_angle.z + Rotate_speed && transform.eulerAngles.z > initial_angle.z - Rotate_speed)
                    transform.eulerAngles = initial_angle;
                else
                    transform.eulerAngles -= rotate_speed_vec*0.4f;
            }
        }
    }
    // Start is called before the first frame update

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBlock : BasicBlock
{
    // Start is called before the first frame update
    public int PointNum;
    public bool loop;
    private int currentP = 0,targeP = 1;
    public float DriftV;
    public float RotateW;
    public Vector2[] RoutL = new Vector2[4];
    private Vector3 targetPosition;
    public int Drift_1_Rotate_2;
    public bool Start_From0;
    private float dd;
    private float rr;

    void Start()
    {
        dd = DriftV*Time.deltaTime * 50;
        rr = RotateW*Time.deltaTime * 50;

        if (Drift_1_Rotate_2 == 1 && Start_From0)
        {
            transform.position = new Vector3(RoutL[0].x, RoutL[0].y, 0);
        }

        currentP = 0;
        targeP = 1;


    }


    protected override void BulletsOn(Collider2D collision)
    {
        //Things happens when bullets on the block
    }
    protected override void BulletsOn(Collision2D collision)
    {
        //Things happens when bullets on the block
    }

    private void MotionDrift()
    {
        targetPosition = new Vector3(RoutL[targeP].x, RoutL[targeP].y, transform.position.z);

        if (Vector3.Distance(transform.position,targetPosition) <= dd * 0.01f)
        {
            transform.position = targetPosition;
            currentP = targeP;
            targeP++;
        }
        else
        {

            transform.position += (targetPosition - transform.position).normalized * dd * 0.01f;
        }
        if (targeP == PointNum)
        {
            if (!loop)
            {
                transform.position = new Vector3(RoutL[0].x, RoutL[0].y, transform.position.z);
                targeP = 1;
            }
            else
            targeP = 0;

        }
    }

    private void MotionRotate()
    {
        transform.eulerAngles += new Vector3(0, 0, rr * 0.1f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Drift_1_Rotate_2 == 1)
        {
            MotionDrift();
        }
        if (Drift_1_Rotate_2 == 2)
        {
            MotionRotate();
        }

    }
}

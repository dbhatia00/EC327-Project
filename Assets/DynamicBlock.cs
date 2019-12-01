using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBlock : BasicBlock
{
    // Start is called before the first frame update
    public int PointNum;
    private int currentP = 0,targeP = 1;
    public float DriftV;
    public float RotateW;
    public Vector2[] RoutL = new Vector2[4];
    private Vector3 targetPosition;
    public int Drift_1_Rotate_2;

    void Start()
    {

        if (Drift_1_Rotate_2 == 1)
        {
            transform.position = new Vector3(RoutL[0].x, RoutL[0].y, 0);
        }

        currentP = 0;
        targeP = 1;


    }

    private void MotionDrift()
    {
        targetPosition = new Vector3(RoutL[targeP].x, RoutL[targeP].y, transform.position.z);

        if (Vector3.Distance(transform.position,targetPosition) <= DriftV * 0.01f)
        {
            transform.position = targetPosition;
            currentP = targeP;
            targeP++;
        }
        else
        {

            transform.position += (targetPosition - transform.position).normalized * DriftV * 0.01f;
        }
        if (targeP == PointNum)
        {
            targeP = 0;
        }
    }

    private void MotionRotate()
    {
        transform.eulerAngles += new Vector3(0, 0, RotateW * 0.1f);
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

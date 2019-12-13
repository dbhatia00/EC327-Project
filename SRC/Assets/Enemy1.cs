using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyObjects
{
    // Start is called before the first frame update
    
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
        base.OnTriggerEnter2D(other);
    }

    protected override void move()
    {
        base.move();
    }

    protected override void fire()
    {
        base.fire(); 
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

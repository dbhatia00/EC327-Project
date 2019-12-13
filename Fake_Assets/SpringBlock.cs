using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBlock : BasicBlock
{
    public bool Horizontal;

    public float impluseRate;

    private Vector2 contactImpluse;

    protected override void BulletsOn(Collider2D collision)
    {
        //Things happens when bullets on the block
    }
    protected override void BulletsOn(Collision2D collision)
    {
        //Things happens when bullets on the block
    }


    protected override void PlayersOn(Collision2D collision)
    {
        contactImpluse = collision.relativeVelocity;
        if (Horizontal)
        {
            if (collision.contacts[0].normal.x == 0)
            {
                collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, -contactImpluse.y * impluseRate);
                if (collision.rigidbody.velocity.magnitude > 60)
                    collision.rigidbody.velocity = collision.rigidbody.velocity.normalized * 15;
            }
        }

        if (!Horizontal)
        {
            if (collision.contacts[0].normal.y == 0)
            {
                collision.rigidbody.velocity = new Vector2(-contactImpluse.x * impluseRate, collision.rigidbody.velocity.y);
                if (collision.rigidbody.velocity.magnitude > 60)
                    collision.rigidbody.velocity = collision.rigidbody.velocity.normalized * 15;
            }
        }
    }
}

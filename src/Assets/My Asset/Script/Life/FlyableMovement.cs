using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyableMovement :  LifeformMovement
{
    private void SetVelocity(Vector2 velocity)
    {
        rigidbody2D.velocity = velocity;
    }
    override public void checkMovement()
    {

    }
    override public void RelativeMovement(Vector2 target, bool towards)
    {
        Vector2 direction = target - (Vector2) transform.position;
        if(direction.magnitude != 0)
        {
            direction /= direction.magnitude;
        }
        direction *= towards? 1:-1;
        setWalking(true);
        SetVelocity( direction * GetSpeed() );
    }
}

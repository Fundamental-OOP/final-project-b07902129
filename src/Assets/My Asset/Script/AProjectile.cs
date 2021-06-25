using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : MonoBehaviour
{

    protected Vector3 direction;
    protected float velocity;
    protected float lifeTime;
    protected abstract void Move();

    public void SetDirection(Vector3 direction) {
        this.direction = direction;
    }

    public void SetVelocity(float velocity) {
        this.velocity = velocity;
    }
}

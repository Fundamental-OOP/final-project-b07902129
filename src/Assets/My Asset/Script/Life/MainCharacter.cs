using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour, IMovable
{
    public enum DIRECTION {
        DIRECTION_LEFT,
        DIRECTION_RIGHT
    }


    protected Vector3 velocity = new Vector3(0,0,0);
    void Update() {
        Move();
    }
    public void Move() {
        gameObject.transform.position += velocity * Time.deltaTime;
    }

    public void SetVelocity(Vector3 vel) {
        velocity = vel;
    }

    public void AddToVelocity(Vector3 changes) {
        velocity += changes;
    }
    public void AddToVelocity(float x, float y, float z) {
        velocity.x += x;
        velocity.y += y;
        velocity.z += z;
    }
}

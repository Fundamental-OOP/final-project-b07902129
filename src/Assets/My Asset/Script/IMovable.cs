using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{

    void SetVelocity(Vector3 vel);

    void AddToVelocity(Vector3 changes);
    void AddToVelocity(float x, float y, float z);

    void Move();
}

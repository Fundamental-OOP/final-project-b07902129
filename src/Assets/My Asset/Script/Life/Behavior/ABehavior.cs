using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors 
{
    [RequireComponent(typeof(LifeformMovement))]
    abstract public class ABehavior : MonoBehaviour
    {
        abstract public void go();
    }
}



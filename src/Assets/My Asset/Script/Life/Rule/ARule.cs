using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviors;

namespace Rules
{
    abstract public class ARule : MonoBehaviour
    {
        public ABehavior behavior;
        abstract public bool Satisfy();
    }
}

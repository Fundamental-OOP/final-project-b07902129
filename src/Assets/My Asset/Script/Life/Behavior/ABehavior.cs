using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors 
{
    abstract public class ABehavior : MonoBehaviour
    {
        public GameObject host;
        abstract public void go();
    }
}



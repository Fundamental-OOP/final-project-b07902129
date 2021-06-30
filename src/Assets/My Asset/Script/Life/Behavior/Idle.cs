using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class Idle : ABehavior
    {
        private LifeformMovement movement;
        void Awake()
        {
            movement = host.GetComponent<LifeformMovement>();
        }
        override public void go()
        {
            
            movement.setWalking(false);
        } 
    }
}



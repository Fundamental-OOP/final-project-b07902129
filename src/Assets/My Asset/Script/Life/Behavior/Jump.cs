using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Behaviors
{
    public class Jump : ABehavior
    {
        public float jumpSpeed = 10f;
        private LifeformMovement movement;
        void Awake()
        {
            movement = host.GetComponent<LifeformMovement>();
        }
        override public void go()
        {
            movement.SetJumpSpeed(jumpSpeed);
            movement.Jump();
           
        }
    }
}

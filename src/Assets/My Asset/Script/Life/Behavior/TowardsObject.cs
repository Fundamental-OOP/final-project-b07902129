using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
namespace Behaviors
{
    public class TowardsObject : ABehavior
    {
        public GameObject target;
        public float speed = 2f;
        private LifeformMovement movement;
        void Awake()
        {
            movement = gameObject.GetComponent<LifeformMovement>();
        }
        override public void go()
        {
            if(target.transform.position.x - gameObject.transform.position.x > 0)
            {
                movement.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
                movement.setWalking(true);
                movement.SetSpeed(speed);
            }
            else
            {
                movement.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
                movement.setWalking(true);
                movement.SetSpeed(speed);
            }
        }
    }
}

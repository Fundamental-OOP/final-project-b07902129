using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
namespace Behaviors
{
    public class TowardsObject : ABehavior
    {
        public GameObject target;
        public float speed;
        private LifeformMovement movement;
        void Awake()
        {
            target = GameObject.Find("MainCharacter");
            movement = host.GetComponent<LifeformMovement>();
        }
        override public void go()
        {
            movement.SetSpeed(speed);
            movement.RelativeMovement((Vector2)target.transform.position,true);
        }
    }
}

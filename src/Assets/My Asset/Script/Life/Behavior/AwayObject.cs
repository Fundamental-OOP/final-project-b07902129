using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Behaviors
{
    public class AwayObject : ABehavior
    {
        public GameObject target;
        public float speed = 2f;
        private LifeformMovement movement;
        void Awake()
        {
            target = GameObject.Find("MainCharacter");
            movement = host.GetComponent<LifeformMovement>();
        }
        override public void go()
        {
            movement.SetSpeed(speed);
            movement.RelativeMovement(target.transform.position, false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Move : AInteraction
    {
        public Vector3 offset;
        public float moveRate;
        public bool forward,move;
        private Vector3 origin,destination;
        public void Awake()
        {
            forward = false;
            move = false;
            origin = transform.position;
            destination = origin + offset;
        }
        new void Update()
        {
            if (!move)
                return;
            if (forward)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, moveRate * Time.deltaTime);
                if(Vector3.Distance(transform.position, destination) < .1f)
                {
                    move = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, origin, moveRate * Time.deltaTime);
                if (Vector3.Distance(transform.position,origin) < .1f )
                {
                    move = false;
                }
            }
        }

        public override void Interact()
        {
            forward = !forward;
            move =  true;
        }


        public override bool Trigger() //not called
        {
            return false;
        }
    }
}


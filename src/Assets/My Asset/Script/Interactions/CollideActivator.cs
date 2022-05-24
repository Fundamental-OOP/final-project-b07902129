using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;
using System;

namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class CollideActivator : AInteraction
    {
        public Type activator; 
        public GameObject activatedObject;
        public bool OnEnter;
        public bool OnExit;
        private bool trigger, active;
        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter collision");
            if(activator == null) //anything
            {
                active = OnEnter;
                trigger = true;
            }else if (col.gameObject.GetComponent(activator))
            {
                active = OnEnter;
                trigger = true;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {

            Debug.Log("exit collision");
            if (activator == null) //anything
            {
                active = OnExit;
                trigger = true;
            }
            else if (col.gameObject.GetComponent(activator))
            {
                active = OnExit;
                trigger = true;
            }
        }

        public override bool Trigger()
        {
            return trigger;
        }
        public override void Interact()
        {
            trigger = false;
            activatedObject.SetActive(active);
        }
    }
}


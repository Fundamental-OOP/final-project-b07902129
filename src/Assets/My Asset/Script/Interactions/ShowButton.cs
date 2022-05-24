using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class ShowButton : AInteraction
    {

        private bool trigger;
        public GameObject button;
        void Awake()
        {
            trigger = false;
            button.SetActive(false);
        }

        new void Update() //do not need to check every frame, hide original update
        {
        }

        public override void Interact()
        {
            button.SetActive(trigger);
        }
        public override bool Trigger() //not called
        {
            return false;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter collision");
            if (ColliderIsPlayer(col))
            {
                
                trigger = true;
                Interact();
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit collision");
            if (ColliderIsPlayer(col))
            {
                trigger = false;
                Interact();
            }
        }
    }
}


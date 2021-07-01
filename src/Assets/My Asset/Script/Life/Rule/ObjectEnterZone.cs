using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rules
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))] 
    public class ObjectEnterZone : ARule 
    {
        public GameObject target;
        //public Collider2D zone;
        private bool inZone = false;
        void Awake()
        {
            target = GameObject.Find("MainCharacter");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            Collider2D col = GetComponent<Collider2D>();
            col.isTrigger = true;

        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == target)
            {
                inZone = true;
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject == target)
            {
                inZone = false;
            }
        }

        override public bool Satisfy()
        {
            return inZone;
        }
    }
}

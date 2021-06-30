using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;
namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Drops))]
    public class Pickup : AInteraction
    {

        public float timeLeft = 500;
        private bool trigger;
        Inventory inventory;
        void Awake()
        {
            trigger = false;
            inventory = GameObject.Find("MainCharacter").GetComponent<Inventory>();
        }
        new void Update()
        {
            base.Update();
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(gameObject);
            }
        }

        public override void Interact()
        {
            Pick();
        }
        public override bool Trigger()
        {
            if (trigger)
            {
                trigger = false;
                return true;
            }
            return false;
        }

        void  OnTriggerEnter2D(Collider2D col)
        {
            if (ColliderIsPlayer(col))
            {
                trigger = true;
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name.Equals("MainCharacter"))
            {
                trigger = true;
            }
        }

        void Pick()
        {
            if (inventory.AddItem(gameObject))
            {
                Debug.Log("pickup!");
            }

        }
    }
}


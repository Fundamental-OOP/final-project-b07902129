using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;
namespace Interactions
{
    public class Pickup : Interaction
    {
        ///public Player player;
        ///public double pickupRange = 0.5;
        public float timeLeft = 5;

        void Update()
        {
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

        void Pick()
        {
            Debug.Log("pickup!");
            Destroy(gameObject);
        }
    }
}


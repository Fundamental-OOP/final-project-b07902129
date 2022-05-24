using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rules
{
    
    public class HealthInRange : ARule
    {
        public Lifeform life;
        public int low, high;

        override public bool Satisfy()
        {
            return (life.health >= low && life.health <= high);
        }
    }
}

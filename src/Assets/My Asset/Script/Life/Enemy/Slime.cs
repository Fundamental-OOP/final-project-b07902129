using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviors;

namespace Enemies
{
    public class Slime : Enemy
    {
        new void Awake()
        {
            base.Awake();
            behaviors = new List<ABehavior>();
            foreach(ABehavior b in GetComponents(typeof(ABehavior)))
            {
                behaviors.Add(b);
            }
            behavior = behaviors[0];
        }

        override public void ChooseBehavior()
        {
            behavior = behaviors[0]; 
        }

        override public void UseEquippedDrop(int id)
        {
            equippedDrops[id].GetComponent<Drops>().SingleUse();
        }

        public override void SetEquippedDrop(GameObject drop, int id)
        {
            equippedDrops[id] = drop;
        }
    }
}


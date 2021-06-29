using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviors;


namespace Enemies
{
    abstract public class Enemy : Lifeform
    {

        public List<ABehavior> behaviors;
        protected ABehavior behavior;
        new void Update()
        {
            base.Update();
            ChooseBehavior();
            behavior.go();
        }
        abstract public void ChooseBehavior();

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
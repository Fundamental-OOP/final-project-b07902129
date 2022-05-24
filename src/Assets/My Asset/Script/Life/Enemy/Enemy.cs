using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviors;
using Rules;
using System;

namespace Enemies
{
    public class Enemy : Lifeform
    {

        public ABehavior defaultMovement;
        public ABehavior movement;
        public List<ARule> movementRules; // choose one movement
        public List<ARule> actionRules;   // can do multiple action
        
        new void Awake()
        {
            base.Awake();
            //movementRules = new List<ARule>();
            //actionRules = new List<ARule>();
            //movementRules = new List<ARule>(GetComponentsInChildren<ARule>());
            movement = defaultMovement;
        }

        new void Update()
        {
            base.Update();
            ChooseMovement(); 
            movement.go();
            foreach (ARule actionRule in actionRules)
            {
                if (actionRule.Satisfy())
                {
                    actionRule.behavior.go();
                }
            }
        }

        public virtual void ChooseMovement()
        {
            foreach(ARule rule in movementRules)
            {
                if (rule.Satisfy())
                {
                    Debug.Log(rule.name);
                    movement = rule.behavior;
                    return;
                }
            }
            movement = defaultMovement; //none satisfied
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
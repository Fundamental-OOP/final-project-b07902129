using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class DamageOnCollide : AInteraction
    {
        public bool destroyOnCollide = false;
        public float damageInterval = 1;
        public int damageValue;
        public List<string> damageTargetTags; //damage all if empty

        private bool collide;
        private Dictionary<GameObject,float> colliders; //collider as key, last collide time as value
        void Awake()
        {
            colliders = new Dictionary<GameObject, float>();
        }

        public override void Interact() 
        {
        }

        public override bool Trigger() // interaction handled in trigger
        {
            List<GameObject>  tList = new List<GameObject>(); //temporaryList of damage object;
            foreach(var collider in colliders)
            {
                if(Time.time - collider.Value > damageInterval)
                {
                    tList.Add(collider.Key);
                }
            }
            if(tList.Count != 0)
            {
                foreach(GameObject victim  in tList)
                {
                    colliders[victim] = Time.time;
                    victim.GetComponent<Lifeform>().addToHealth(-damageValue);
                }
                if (destroyOnCollide)
                {
                    gameObject.SetActive(false);
                }
            }
            return false;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if(damageTargetTags.Count == 0) // damage all lifeform
            {
                if (col.gameObject.GetComponent<Lifeform>()!=null)
                {
                    colliders.Add(col.gameObject, Time.time);
                }
            }
            else
            {
                foreach (string targetTag in damageTargetTags)
                {
                    if (col.tag.Equals(targetTag))
                    {
                        colliders.Add(col.gameObject, Time.time);
                    }
                }
            }
  

        }

        void OnTriggerExit2D(Collider2D col)
        {
            if(colliders.ContainsKey(col.gameObject)){
                colliders.Remove(col.gameObject);
            }
        }
    }
}

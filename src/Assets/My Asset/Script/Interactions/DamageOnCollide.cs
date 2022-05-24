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
        private GameObject victim;
        private Dictionary<GameObject, float> victims; //collider as key, last collide time as value
        private List<GameObject> colliders; //collider as key, last collide time as value
        void Awake()
        {
            victims = new Dictionary<GameObject, float>();
            colliders = new List<GameObject>();
        }

        public override void Interact() //called by trigger or OnCollideEnter
        {
            if (victims.ContainsKey(victim))
            {
                if (Time.time - victims[victim] > damageInterval)
                {
                    Damage(victim);
                }
            }
            else
            {
                victims.Add(victim, Time.time);
                Damage(victim);
                
            }
        }
        private void Damage(GameObject victim)
        {
            victims[victim] = Time.time;
            victim.GetComponent<Lifeform>().AddToHealth(-damageValue);
            if (destroyOnCollide)
                gameObject.SetActive(false);
        }
        public override bool Trigger()  //direct call interact
        {
            for(int i = 0; i <  colliders.Count;i++)
            {
                victim = colliders[i];
                Interact();
            }
            return false;
        }

        bool IsTarget(GameObject collider)
        {
            if (damageTargetTags.Count == 0 && collider.GetComponent<Lifeform>() != null)
            {
                return true;
            }
            foreach (string targetTag in damageTargetTags)
            {
                if (collider.tag.Equals(targetTag))
                {
                    return true;
                }
            }
            return false;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (IsTarget(col.gameObject))
            {
                if (!colliders.Contains(col.gameObject))
                {
                    colliders.Add(col.gameObject);
                }
                victim = col.gameObject;
                Interact();
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (colliders.Contains(col.gameObject))
            {
                colliders.Remove(col.gameObject);
            }
        }


        void OnCollisionEnter2D(Collision2D col)
        {
            if (IsTarget(col.gameObject))
            {
                if (!colliders.Contains(col.gameObject))
                {
                    colliders.Add(col.gameObject);
                }
                victim = col.gameObject;
                Interact();
            }
        }
        void OnCollisionExit2D(Collision2D col)
        {
            if (colliders.Contains(col.gameObject))
            {
                colliders.Remove(col.gameObject);
            }
        }
    }
}

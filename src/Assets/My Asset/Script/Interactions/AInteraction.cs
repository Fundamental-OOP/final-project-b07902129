using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;

namespace Interactions
{
    public abstract class AInteraction : MonoBehaviour
    {
        public void Update()
        {
            if (Trigger())
            {
                Interact();
            }
        }
        public abstract bool Trigger();
        public abstract void Interact();

        public bool ColliderIsPlayer(Collider2D col)
        { 
            return (col.gameObject.name.Equals("MainCharacter"));
        }

        /*void OnMouseDown()
        {
            Interact();
        }*/

        /*public virtual void CheckInteraction(float dist, Player player)
        {
            Display(Trigger(dist, player));
        }*/

        /*public void Display(bool trigger)
        {
            Debug.Log(trigger);
            gameObject.SetActive(trigger ? true : false);
        }*/


        /*public bool Trigger(float dist, Player player)
        {
            if (dist < triggerDistance)
            {
                return true;
            }
            return false;
        }*/

    }
}

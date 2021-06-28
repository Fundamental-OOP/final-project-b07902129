using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;

namespace Interactions
{
    public class Interaction : MonoBehaviour
    {
        public Player player;

        

        public virtual void Interact()
        {

        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("col");
            if (col.gameObject.GetComponent<Player>())
            {
                Interact();
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.GetComponent<Player>())
            {
                
            }
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

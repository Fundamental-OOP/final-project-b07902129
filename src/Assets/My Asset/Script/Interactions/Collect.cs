using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Dropper))]
    public class Collect : AInteraction
    {
        public Inventory playerInventory;
        public int dropCount = 1;
        public int hitCount = 5;
        public Dropper dropper;
        public string[] collectTool ;
        private bool collide, click;
        private Color originalColor;
        public void Awake()
        {
            originalColor = gameObject.GetComponent<SpriteRenderer>().color;
            playerInventory = GameObject.Find("MainCharacter").GetComponent<Inventory>();
            collide = false;
            click = false;
            dropper = gameObject.GetComponent<Dropper>();
        }


        public override bool Trigger()
        {
            if (collide && click)
            { 
                foreach(string s in collectTool)
                {
                    if (playerInventory.InHand(s))
                    {
                        click = false;
                        return true;
                    }
                }

            }
            click = false;
            return false;
        }

        public override void Interact()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            hitCount--;
            if (hitCount == 0)
            {
                for(int i = 0; i < dropCount; i++)
                {
                    dropper.Drop();
                }
                gameObject.SetActive(false);
            }
        }

        void OnMouseDown()
        {
            click = true;
        }

        void OnMouseUp()
        {
            gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (ColliderIsPlayer(col) )
            {
                collide = true;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (ColliderIsPlayer(col))
            {
                collide = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Place : AInteraction
    {
        private bool trigger;
        public Placable placedObject;
        public override bool Trigger()
        {
            return trigger;
        }
        public override void Interact()
        {
            Debug.Log("placing");
            placedObject.Place();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Place : Interaction
    {
        public Placable placedObject;
        public override void Interact()
        {
            Debug.Log("placing");
            placedObject.Place();
        }
    }
}

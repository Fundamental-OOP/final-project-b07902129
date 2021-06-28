using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractButton : MonoBehaviour
    {
        // Start is called before the first frame update

        public AInteraction interaction;
        void OnMouseDown()
        {
            interaction.Interact();
        }
    }

}

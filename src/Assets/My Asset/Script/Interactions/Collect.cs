using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Collect : Interaction
    {
        public GameObject collectFrom;
        public int collectCount = 1;
        public override void Interact()
        {
            collectFrom.GetComponent<Dropper>().Drop();
            collectCount--;
            if (collectCount == 0)
            {
                Destroy(collectFrom);
            }
        }
    }
}

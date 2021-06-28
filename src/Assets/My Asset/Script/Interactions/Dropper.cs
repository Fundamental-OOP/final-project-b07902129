using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Dropper : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject droppedObject;
        public Vector3 offset = new Vector3(0, 0, 0);
        public void Start()
        {
            ///droppedObject.SetActive(false);
        }
        public void Drop()
        {
            GameObject newObject = Instantiate(droppedObject, DropPos(), Quaternion.identity) as GameObject;
            newObject.SetActive(true);
        }
        Vector3 DropPos()
        {
            return gameObject.transform.position + offset;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;

namespace Interactions
{
    public class Placable : MonoBehaviour
    {
        public GameObject placedObject;
        public GameObject player;
        public Vector3 offset = new Vector3(0, 0, 0);


        void Start()
        {
            player = GameObject.Find("MainCharacter");
            ///placedObject.SetActive(false);
        }

        public void Place()
        {
            Debug.Log("place?");
            ///Instantiate(placedObject);
            GameObject newObject =  Instantiate(placedObject,PlacePos(), Quaternion.identity) as GameObject;
            newObject.transform.name = newObject.transform.name.Replace("(Clone)", "").Trim();
            newObject.SetActive(true);
        }

        Vector3 PlacePos()
        {
            return player.transform.position + offset;
        }
    }
}

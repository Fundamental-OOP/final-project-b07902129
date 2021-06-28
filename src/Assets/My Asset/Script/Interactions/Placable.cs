using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LifeForm;

namespace Interactions 
{
    public class Placable : MonoBehaviour
    {
        public GameObject placedObject;
        public Vector3 offset = new Vector3(0, 0, 0);
        public Player player;

        void Start()
        {
            player = GameObject.Find("MainCharacter").GetComponent(typeof(Player)) as Player;
            ///placedObject.SetActive(false);
        }

        public void Place()
        {
            ///Instantiate(placedObject);
            GameObject newObject =  Instantiate(placedObject,PlacePos(), Quaternion.identity) as GameObject;
            newObject.SetActive(true);
        }

        Vector3 PlacePos()
        {
            return player.GetPos() + offset;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableSlot : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void OnMouseDown()
    {
        if(gameObject.transform.childCount == 1)
        {
            GameObject item = gameObject.transform.GetChild(0).gameObject;
            item.GetComponent<Drops>().Use();
        }
        else if (gameObject.transform.childCount == 0)
        {
            Debug.Log("UseSlot empty");
        }
        else
        {
            Debug.Log("UseSlot item count wrong!");
        }
    }
}

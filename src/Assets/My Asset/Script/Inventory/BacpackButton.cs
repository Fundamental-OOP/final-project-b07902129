using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backpackUI; 
    void Start()
    {
        backpackUI = GameObject.Find("Backpack");
        backpackUI.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        backpackUI.SetActive(!backpackUI.active);
    }
}

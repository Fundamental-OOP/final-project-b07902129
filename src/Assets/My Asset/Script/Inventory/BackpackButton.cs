using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backpackUI;
    public UnityEngine.UI.Button[] useButton;

    void Start()
    {
        backpackUI = GameObject.Find("Backpack");
        backpackUI.SetActive(false);
        useButton[0].enabled = true;
        useButton[1].enabled = true;
        useButton[0].onClick.AddListener(delegate { UseButton(useButton[0]); });
        useButton[1].onClick.AddListener(delegate { UseButton(useButton[1]); });
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        //use slot is not usable when in backpack ui
        useButton[0].enabled = !useButton[0].enabled;
        useButton[1].enabled = !useButton[1].enabled;
        backpackUI.SetActive(!backpackUI.active);
    }

    void UseButton(UnityEngine.UI.Button button)
    {
        if (button.gameObject.transform.childCount == 1)
        {
            GameObject item = button.gameObject.transform.GetChild(0).gameObject;
            item.GetComponent<Drops>().Use();
        }
        else if (button.gameObject.transform.childCount == 0)
        {
            Debug.Log("UseSlot empty");
        }
        else
        {
            Debug.Log("UseSlot item count wrong!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops:MonoBehaviour
{
    public Sprite sprite;
    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }
    public virtual void Use()
    {
        Debug.Log("using" + gameObject.name);
    }
}

using UnityEngine;

public class Drops : MonoBehaviour
{
    public Sprite sprite;
    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }
    public Sprite GetSprite() {
        return sprite;
    }

    // fire once when usableslot is pressed
    public virtual void SingleUse() {
        Debug.Log("Single use" + gameObject.name);
    }

    // fire when usableslot is hold
    public virtual void HoldUse() {
        Debug.Log("Hold use" + gameObject.name);
    }

    // initailzation when equipped
    public virtual void OnEquipped() {}

    // passive ability called every update
    public virtual void Passive() {}
}

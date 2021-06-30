using UnityEngine;
using Interactions;

public class Potion : Drops
{
    public Lifeform host;
    public int healAmount = 50;
    // fire once when usableslot is pressed
    override public void SingleUse()
    {
        host.AddToHealth(healAmount);
        Debug.Log("using" + gameObject.name);
        Destroy(gameObject);
    }

    // fire when usableslot is hold
    public virtual void HoldUse()
    {
        Debug.Log("Hold use" + gameObject.name);
    }

    // initailzation when equipped
    public virtual void OnEquipped() { }

    // passive ability called every update
    public virtual void Passive() { }
}
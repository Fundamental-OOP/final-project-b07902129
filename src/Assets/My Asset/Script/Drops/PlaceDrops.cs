using UnityEngine;
using Interactions;

[RequireComponent(typeof(Placable))]
public class PlaceDrops : Drops
{


    // fire once when usableslot is pressed
    override public  void SingleUse()
    {
        GetComponent<Placable>().Place();
        Debug.Log("placing" + gameObject.name);
        Destroy(gameObject);
    }

    // fire when usableslot is hold
    public override void HoldUse()
    {
        Debug.Log("Hold use" + gameObject.name);
    }

    // initailzation when equipped
    public override void OnEquipped() { }

    // passive ability called every update
    public override void Passive() { }
}

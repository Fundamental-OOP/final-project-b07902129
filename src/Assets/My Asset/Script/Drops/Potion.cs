using UnityEngine;
using Interactions;

public class Potion : Drops
{
    public Lifeform host;
    public int healAmount = 300;
    // fire once when usableslot is pressed

    void Awake() {
        host = GameObject.Find("MainCharacter").gameObject.GetComponent<MainCharacter>();
    }
    override public void SingleUse()
    {
        host.AddToHealth(healAmount);
        Debug.Log("using" + gameObject.name);
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

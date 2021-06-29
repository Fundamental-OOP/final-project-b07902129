using UnityEngine;

public class MainCharacter : Lifeform
{
    override public void UseEquippedDrop(int id) {
        equippedDrops[id].GetComponent<Drops>().SingleUse();
    }

    public override void SetEquippedDrop(GameObject drop, int id) {
        equippedDrops[id] = drop;
    }
}
using UnityEngine;

public class MainCharacter : Lifeform
{
    override public void useEquippedDrop(int id) {
        equippedDrops[id].GetComponent<Drops>().use();
    }

    public override void setEquippedDrop(GameObject drop, int id) {
        equippedDrops[id] = drop;
    }
}
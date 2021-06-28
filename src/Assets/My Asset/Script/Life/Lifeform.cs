using UnityEngine;

abstract public class Lifeform : MonoBehaviour
{
    protected int lifeformLayer = 6;
    protected int health;
    protected GameObject[] equippedDrops = new GameObject[2];

    abstract public void useEquippedDrop(int id);

    abstract public void setEquippedDrop(GameObject drop, int id);

    public void addToHealth(int amount) {
        health += amount;
    }

}
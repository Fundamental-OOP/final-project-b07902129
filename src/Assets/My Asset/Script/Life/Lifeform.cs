using UnityEngine;

abstract public class Lifeform : MonoBehaviour
{
    protected int lifeformLayer = 6;
    public int health;
    protected GameObject[] equippedDrops = new GameObject[2];

    abstract public void UseEquippedDrop(int id);

    abstract public void SetEquippedDrop(GameObject drop, int id);

    public void AddToHealth(int amount) {
        health += amount;
    }

}
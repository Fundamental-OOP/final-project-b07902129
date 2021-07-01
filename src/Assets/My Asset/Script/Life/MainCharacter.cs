using UnityEngine;

public class MainCharacter : Lifeform
{
    public GameObject deathScene;
    void Start()
    {
       
        deathScene.SetActive(false);
    }
    override public void Death()
    {
        gameObject.SetActive(false);
        deathScene.SetActive(true);
    }
    override public void UseEquippedDrop(int id) {
        equippedDrops[id].GetComponent<Drops>().SingleUse();
    }

    public override void SetEquippedDrop(GameObject drop, int id) {
        equippedDrops[id] = drop;
    }
}
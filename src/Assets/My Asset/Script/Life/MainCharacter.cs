using UnityEngine;

public class MainCharacter : Lifeform
{
    public DeathUI deathScene;
    void Start()
    {

    }
    override public void Death()
    {
        gameObject.SetActive(false);
        deathScene.OpenDeathMenu();
    }
    override public void UseEquippedDrop(int id) {
        equippedDrops[id].GetComponent<Drops>().SingleUse();
    }

    public override void SetEquippedDrop(GameObject drop, int id) {
        equippedDrops[id] = drop;
    }
}
using UnityEngine;
using System.Collections;

abstract public class Lifeform : MonoBehaviour
{
    protected int lifeformLayer = 6;
    public int health;
    protected GameObject[] equippedDrops = new GameObject[2];

    abstract public void UseEquippedDrop(int id);

    abstract public void SetEquippedDrop(GameObject drop, int id);
    private Color originalColor;
    private float flashTime = 0.1f;
    private float prevFlashTime = 0;
    public bool flash;

    public void Awake()
    {
        flash = false;
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void Update()
    {
        if (flash && (Time.time - prevFlashTime >= flashTime))
        {
            flash = false;
            gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
    public void AddToHealth(int amount) {
        health += amount;
        if(amount < 0)
        {
            OnDamage();
        }
    }

    public virtual void OnDamage()
    {
        Flash();
        if (health <= 0)
        {
            Death();
        }
    }
    public virtual void Death()
    {
        gameObject.SetActive(false);
    }
    private void Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        prevFlashTime = Time.time;
        flash = true;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AProjectile
{
    void Awake()
    {
        velocity = 0;
        lifeTime = 10;
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DecreaseLife();
    }

    void DecreaseLife() {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0 )
            Destroy(gameObject);
    }

    override protected void Move() {
        transform.position += velocity * Time.deltaTime * direction;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "MainCharacter" || collider.gameObject.layer == 8)
            return;
        LoadExplosion();
        Destroy(gameObject);
    }

    private void LoadExplosion() {
        GameObject explosion = Instantiate( Resources.Load("Prefab/Explosion", typeof(GameObject)) as GameObject);
        explosion.transform.position = transform.position + direction * 0.1f;
    }

}

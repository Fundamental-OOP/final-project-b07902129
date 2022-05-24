using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class AttackMagic : MonoBehaviour
{

    public GameObject projectile;

    private Animator animator;

    private float coolDown = 1.0f;
    private float coolDownTimer = 0.0f;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        coolDownTimer = coolDown + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDownTimer > coolDown) {
            animator.SetBool("isAttacking", true);
        }
        coolDownTimer += Time.deltaTime;
    }

    private void loadBullet(Vector3 direction, float angle) {
        GameObject bullet = Instantiate( Resources.Load("Prefab/Bullet", typeof(GameObject)) as GameObject);
        bullet.GetComponent<AProjectile>().SetDirection(direction);
        bullet.GetComponent<AProjectile>().SetVelocity(2.0f);
        bullet.transform.Rotate(0, 0, angle);
        bullet.transform.position = transform.position;
    }

    private void fire() {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        Vector3 direction = Vector3.Normalize(clickPosition - transform.position);

        float angle = Vector3.Angle(Vector3.right, direction);
        if (clickPosition.y < transform.position.y) angle = -angle;

        loadBullet(direction, angle);

        coolDownTimer = 0.0f;
        animator.SetBool("isAttacking", false);
    }

    private GameObject createBulletLight() {
        GameObject light = new GameObject("Bullet Light");
        Light2D lightComponent = light.AddComponent<Light2D>();
        lightComponent.lightType = Light2D.LightType.Point;
        lightComponent.pointLightInnerRadius = 0;
        lightComponent.pointLightOuterRadius = .85f;
        lightComponent.intensity = 3.0f;
        lightComponent.color = new Color(195, 88, 255, 1);
        light.transform.position = transform.position;
        return light;
    }

    private GameObject cloneBullet(Vector3 direction, float angle) {
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.GetComponent<AProjectile>().SetDirection(direction);
        clone.GetComponent<AProjectile>().SetVelocity(1.0f);
        clone.transform.Rotate(0, 0, angle);
        return clone;
    }

}

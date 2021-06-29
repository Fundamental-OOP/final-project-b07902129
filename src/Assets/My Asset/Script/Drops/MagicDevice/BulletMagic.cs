using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletMagic : AMagicDevice
{
    private static GameObject projectile;
    private Animator animator;

    private ObjectFollower follower;

    private bool isActivate = false;

    void Awake() {
        projectile = PrefabLoadder.loadPrefab("Prefab/Bullet");
        coolDown = 1.0f;
        animator = GetComponent<Animator>();
        follower = GetComponent<ObjectFollower>();
        coolDownTimer = coolDown + 1;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && coolDownTimer > coolDown && isActivate) {
            if (EventSystem.current.IsPointerOverGameObject(0))
                Debug.Log("PointerOverGameObject");
            animator.SetBool("isAttacking", true);
        }
        coolDownTimer += Time.deltaTime;
        follower.Follow();
    }

    override public void SingleUse() {
        isActivate = !isActivate;
    }

    public override void OnEquipped() {
        Debug.Log("OnEquipped");
        follower.InitPosition();
    }

    private void InstantiateBullet(Vector3 direction, float angle) {
        GameObject bullet = Instantiate( projectile );
        bullet.GetComponent<AProjectile>().SetDirection(direction);
        bullet.GetComponent<AProjectile>().SetVelocity(2.0f);
        bullet.transform.Rotate(0, 0, angle);
        bullet.transform.position = transform.position;
    }

    // called from animator
    private void Fire() {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0;
        Vector3 direction = Vector3.Normalize(clickPosition - transform.position);

        float angle = Vector3.Angle(Vector3.right, direction);
        if (clickPosition.y < transform.position.y) angle = -angle;

        InstantiateBullet(direction, angle);

        coolDownTimer = 0.0f;
        animator.SetBool("isAttacking", false);
    }

}

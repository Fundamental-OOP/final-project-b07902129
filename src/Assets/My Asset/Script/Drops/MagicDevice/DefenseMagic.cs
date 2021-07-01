using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class DefenseMagic : AMagicDevice
{
    private SpriteRenderer spriteRenderer;
    private ObjectFollower follower;
    private bool fadeOut = false;
    private float fadeSpeed = 2.0f;

    void Awake() {
        lid = transform.Find("LightIntensityDetector").gameObject.GetComponent<LightIntensityDetector>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        follower = gameObject.GetComponent<ObjectFollower>();
        follower.target = GameObject.Find("MainCharacter");
        coolDown = 10;
        coolDownTimer = coolDown;
        requiredLightIntensity = 0.3f;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "EnemyFire" && coolDownTimer > coolDown && MeetLightIntensity()) {
            Debug.Log(string.Format("Defense tag: {0}",col.gameObject.tag));
            Destroy(col.gameObject);
            fadeOut = true;
            coolDownTimer = 0f;
        }
    }

    public override void Passive() {
        if (fadeOut) {
            fadeColliderAlpha(0);
            if (spriteRenderer.color.a <= 0.01f)
                fadeOut = false;
        }

        if (coolDownTimer > coolDown)
            fadeColliderAlpha(1);
        coolDownTimer += Time.deltaTime;
    }

    private void fadeColliderAlpha(float target) {
        float alpha = Mathf.MoveTowards(spriteRenderer.color.a, target, fadeSpeed * Time.deltaTime);
        spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
    }

    public override void OnEquipped() {
        Debug.Log("OnEquipped");
        follower.InitPosition();
    }

}

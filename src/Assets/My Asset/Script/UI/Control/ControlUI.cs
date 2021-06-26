using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : ACanvas
{
    public GameObject characterGameObject;
    private AButton left;
    private AButton right;
    private AButton jump;
    private MainCharacter mainCharacter;

    void Awake() {
        mainCharacter = characterGameObject.GetComponent<MainCharacter>();
        left = gameObject.transform.Find("left").gameObject.GetComponent<AButton>();
        right = gameObject.transform.Find("right").gameObject.GetComponent<AButton>();
        jump = gameObject.transform.Find("jump").gameObject.GetComponent<AButton>();
    }

    void Update() {
        UpdateCharacterMovement();
    }

    void UpdateCharacterMovement() {
        mainCharacter.setJumping(jump.isPressed());
        if (left.isPressed()) {
            mainCharacter.setWalking(true);
            mainCharacter.setLifeformDirection(Lifeform.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
        }
        else if (right.isPressed()) {
            mainCharacter.setWalking(true);
            mainCharacter.setLifeformDirection(Lifeform.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
        }
        else
            mainCharacter.setWalking(false);
    }
}

using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public GameObject characterGameObject;
    private AButton left;
    private AButton right;
    private AButton jump;
    private MainCharacterMovement mainCharacter;

    void Awake() {
        mainCharacter = characterGameObject.GetComponent<MainCharacterMovement>();
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
            mainCharacter.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
        }
        else if (right.isPressed()) {
            mainCharacter.setWalking(true);
            mainCharacter.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
        }
        else
            mainCharacter.setWalking(false);
    }
}
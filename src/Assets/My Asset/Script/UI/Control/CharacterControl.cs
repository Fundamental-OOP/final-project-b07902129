using UnityEngine;

public class CharacterControl : MonoBehaviour {
    public GameObject characterGameObject;
    private SimpleButton left;
    private SimpleButton right;
    private SimpleButton jump;
    private MainCharacterMovement mainCharacter;

    void Awake() {
        mainCharacter = characterGameObject.GetComponent<MainCharacterMovement>();
        left = gameObject.transform.Find("left").gameObject.GetComponent<SimpleButton>();
        right = gameObject.transform.Find("right").gameObject.GetComponent<SimpleButton>();
        jump = gameObject.transform.Find("jump").gameObject.GetComponent<SimpleButton>();
    }

    void Update() {
        UpdateCharacterMovement();
    }

    void UpdateCharacterMovement() {
        mainCharacter.setJumping(jump.IsPressed());
        if (left.IsPressed()) {
            mainCharacter.setWalking(true);
            mainCharacter.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
        }
        else if (right.IsPressed()) {
            mainCharacter.setWalking(true);
            mainCharacter.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
        }
        else
            mainCharacter.setWalking(false);
    }
}
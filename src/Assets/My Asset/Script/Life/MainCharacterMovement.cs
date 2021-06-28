using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : LifeformMovement
{
    private float speed = 3f;
    private float jumpSpeed = 6.5f;
    private float stepHeightOffset = .2f;
    private bool isWalking = false;
    private bool isJumping = false;
    private Animator animator;

    void Awake() {
        animator = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        currentDirection = LIFEFORM_FACING.LIFEFORM_FACING_RIGHT;
        rigidbody2D.constraints |= RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() {
        checkJump();
        checkFacing();
    }

    void FixedUpdate() {
        checkMovement();
    }

    public void setJumping(bool jump) {
        isJumping = jump;
    }

    public void setWalking(bool walk) {
        isWalking = walk;
    }

    private void checkMovement() {
        animator.SetBool("isWalking", isWalking);
        if (isWalking) {
            if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_LEFT)
                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            else if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_RIGHT)
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }

    private void checkJump() {
        Debug.Log(isGrounded());
        if (isJumping && isGrounded()) {
            animator.SetBool("isJumping", isJumping);
        }
    }

    public void endJump() {
        animator.SetBool("isJumping", false);
    }

    public void startJump() {
        rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpSpeed);
    }

    private void checkFacing() {
        if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_LEFT && gameObject.transform.eulerAngles.y == 0)
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, 180, gameObject.transform.rotation.z);
        else if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_RIGHT && gameObject.transform.eulerAngles.y == 180)
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, 0, gameObject.transform.rotation.z);
    }

    private void updateFacing() {
        switch(currentDirection) {
            case LIFEFORM_FACING.LIFEFORM_FACING_LEFT:
                break;
            case LIFEFORM_FACING.LIFEFORM_FACING_RIGHT:
                break;
        }
    }

    override public Vector3 getPos() {
        return gameObject.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (!isWalking)
            return;
        for (int i = 0; i < collision.contactCount; i++) {
            ContactPoint2D contactPoint = collision.GetContact(i);
            if (contactPoint.point.y < (boxCollider2D.bounds.center.y - boxCollider2D.bounds.extents.y + stepHeightOffset)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            contactPoint.point.y + boxCollider2D.bounds.extents.y + stepHeightOffset,
                                                            gameObject.transform.position.z);
                return;
            }

        }
    }
}

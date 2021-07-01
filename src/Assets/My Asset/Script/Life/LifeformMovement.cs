using UnityEngine;

[RequireComponent(typeof(Lifeform))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class LifeformMovement : MonoBehaviour
{
    public enum LIFEFORM_FACING {
        LIFEFORM_FACING_LEFT,
        LIFEFORM_FACING_RIGHT
    };

    private float isGroundedOffst = 0.5f;
    protected int lifeformLayer = 6;
    protected LIFEFORM_FACING currentDirection;
    protected new Rigidbody2D rigidbody2D;
    protected BoxCollider2D boxCollider2D;

    public float speed = 3f;
    public float jumpSpeed = 6.5f;
    public float stepHeightOffset = 0.1f;
    private bool isWalking = false;
    private bool isJumping = false;
    private Animator animator;
    private float jumpApproximate = 2f; // movetowards will start jumping when close enough


    void Awake()
    {
        Physics2D.queriesStartInColliders = false;
        animator = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        currentDirection = LIFEFORM_FACING.LIFEFORM_FACING_RIGHT;
        rigidbody2D.constraints |= RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        checkJump();
        checkFacing();
    }

    void FixedUpdate()
    {
        checkMovement();
    }


    public void setLifeformDirection(LIFEFORM_FACING direction) {
        currentDirection = direction;
    }

    public bool isGrounded() {
        int mask = ~(LayerMask.GetMask("MainCharacter") | LayerMask.GetMask("Ignore Raycast"));
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + isGroundedOffst, mask);
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * boxCollider2D.bounds.extents.y, Color.red, 1);
        //if (hit.collider != null)
         //   Debug.Log(hit.collider.gameObject.name);
        return hit.collider != null;
    }


    public void setJumping(bool jump)
    {
        isJumping = jump;
    }

    public void setWalking(bool walk)
    {
        isWalking = walk;
    }

    public virtual void checkMovement()
    {
        animator.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_LEFT)
                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            else if (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_RIGHT)
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }



    private void checkJump()
    {
        Debug.Log(isGrounded());
        if (isJumping && isGrounded())
        {
            animator.SetBool("isJumping", isJumping);
        }
    }

    public void endJump()
    {
        animator.SetBool("isJumping", false);
    }

    public void startJump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
    }
    public bool IsJumping()
    {
        return isJumping;
    }

    private void checkFacing()
    {
        if ((currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_LEFT && gameObject.transform.localScale.x > 0) ||
             (currentDirection == LIFEFORM_FACING.LIFEFORM_FACING_RIGHT && gameObject.transform.localScale.x < 0))
            gameObject.transform.localScale = new Vector3(-1 * gameObject.transform.localScale.x,
                                                            gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    private void updateFacing()
    {
        switch (currentDirection)
        {
            case LIFEFORM_FACING.LIFEFORM_FACING_LEFT:
                break;
            case LIFEFORM_FACING.LIFEFORM_FACING_RIGHT:
                break;
        }
    }

    public Vector3 getPos()
    {
        return gameObject.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isWalking)
            return;
        for (int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint2D contactPoint = collision.GetContact(i);
            if (contactPoint.point.y < (boxCollider2D.bounds.center.y - boxCollider2D.bounds.extents.y + stepHeightOffset))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            contactPoint.point.y + boxCollider2D.bounds.extents.y + stepHeightOffset,
                                                            gameObject.transform.position.z);
                return;
            }

        }
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetJumpSpeed(float jumpSpeed)
    {
        this.jumpSpeed = jumpSpeed;
    }

    public void SetStepHeightOffset(float step)
    {
        stepHeightOffset = step;
    }
    public virtual void RelativeMovement(Vector2 target, bool towards)
    {
        if (target.x - transform.position.x > 0)
        {
            setLifeformDirection(towards? LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT: LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
        }
        else
        {
            setLifeformDirection(towards? LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT : LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
        }
        setWalking(true);

        if (target.y - transform.position.y > 0 && Mathf.Abs(target.x - transform.position.x) < boxCollider2D.size.x * jumpApproximate)
        {
            Jump();
        }
        else
        {
            setJumping(false);
            endJump();
        }
    }

    public void Jump()
    {

        if (!IsJumping() && isGrounded())
        {
            setJumping(true);
            startJump();
        }
        else
        {
            if (isGrounded())
            {
                setJumping(false);
                endJump();
            }
        }
    }
}
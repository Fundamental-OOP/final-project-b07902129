using UnityEngine;

abstract public class Lifeform : MonoBehaviour
{
    public enum LIFEFORM_FACING {
        LIFEFORM_FACING_LEFT,
        LIFEFORM_FACING_RIGHT
    };

    private float isGroundedOffst = 0.5f;
    protected int lifeformLayer = 6;
    protected int health;
    protected LIFEFORM_FACING currentDirection;
    protected Drops[] equippedDrops = new Drops[2];
    protected Rigidbody2D rigidbody2D;
    protected BoxCollider2D boxCollider2D;
    abstract public Vector3 getPos();
    abstract public void useEquippedDrop(int id);

    public void addToHealth(int amount) {
        health += amount;
    }

    public void setLifeformDirection(LIFEFORM_FACING direction) {
        currentDirection = direction;
    }

    protected bool isGrounded() {
        int mask = ~(1 << lifeformLayer);
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + isGroundedOffst, mask);
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * boxCollider2D.bounds.extents.y, Color.red, 1);
        return hit.collider != null;
    }

}
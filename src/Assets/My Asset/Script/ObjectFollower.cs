using UnityEngine;

public class ObjectFollower : MonoBehaviour {
    public GameObject target;
    public Vector3 offset;
    public float speed = 5.0f;

    public bool targetDirectionSensitive = true;

    void Update() {
        AdjustOffsetByTargetDirection();
        Follow();
    }

    public virtual void Follow() {
        float newX = Mathf.MoveTowards(gameObject.transform.position.x, target.transform.position.x + offset.x, speed * Time.deltaTime);
        float newY = Mathf.MoveTowards(gameObject.transform.position.y, target.transform.position.y + offset.y, speed * Time.deltaTime);
        float newZ = Mathf.MoveTowards(gameObject.transform.position.z, target.transform.position.z + offset.z, speed * Time.deltaTime);
        gameObject.transform.position = new Vector3(newX, newY, newZ);
    }

    public void InitPosition() {
        AdjustOffsetByTargetDirection();
        gameObject.transform.position = target.transform.position + offset;
    }

    private void AdjustOffsetByTargetDirection() {
        if (!targetDirectionSensitive) return;
        if (target.transform.localScale.x < 0) offset.x *= -1;
        if (target.transform.localScale.y < 0) offset.y *= -1;
        if (target.transform.localScale.z < 0) offset.z *= -1;
    }

}
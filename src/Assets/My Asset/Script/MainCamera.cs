using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject mainCharacter;
    private float maxSpeed = 5.0f;
    private float followYThreshold = 10;
    private Vector3 minCoordinate = new Vector3(-15, -15, -100);
    private Vector3 maxCoordinate = new Vector3(100, 100, 100);

    void Update() {
        followCharacter();
    }

    private void followCharacter() {
        float newX = Mathf.MoveTowards(gameObject.transform.position.x, mainCharacter.transform.position.x, maxSpeed * Time.deltaTime);

        newX = Mathf.Clamp(newX, minCoordinate.x, maxCoordinate.x);

        float newY = 0;
        if (Mathf.Abs(gameObject.transform.position.y - mainCharacter.transform.position.y) > followYThreshold)
            newY = Mathf.MoveTowards(gameObject.transform.position.y, mainCharacter.transform.position.y, maxSpeed * Time.deltaTime);
        newY = Mathf.Clamp(newY, minCoordinate.y, maxCoordinate.y);

        gameObject.transform.position = new Vector3(newX, newY, gameObject.transform.position.z);
    }
}

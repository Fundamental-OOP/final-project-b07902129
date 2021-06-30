using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject mainCharacter;
    public float maxSpeed = 5.0f;
    public float followYThreshold = 2;
    public Vector3 minCoordinate = new Vector3(-15, -15, -100);
    public Vector3 maxCoordinate = new Vector3(100, 100, 100);

    void Update() {
        followCharacter();
    }

    private void followCharacter() {
        float newX = Mathf.MoveTowards(gameObject.transform.position.x, mainCharacter.transform.position.x, maxSpeed * Time.deltaTime);

        newX = Mathf.Clamp(newX, minCoordinate.x, maxCoordinate.x);

        float newY = 0;
        if (Mathf.Abs(gameObject.transform.position.y - mainCharacter.transform.position.y + 1) > followYThreshold)
            newY = Mathf.MoveTowards(gameObject.transform.position.y, mainCharacter.transform.position.y + 1, maxSpeed * Time.deltaTime);
        else
            newY = gameObject.transform.position.y+1;
        newY = Mathf.Clamp(newY, minCoordinate.y, maxCoordinate.y+1);

        gameObject.transform.position = new Vector3(newX, newY, gameObject.transform.position.z);
    }
}

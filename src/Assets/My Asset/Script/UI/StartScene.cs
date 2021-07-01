using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public float lastFor = 3f;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (Time.time - startTime > lastFor)
        {
            gameObject.SetActive(false);
        }
    }
}

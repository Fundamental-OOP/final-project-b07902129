using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Restart : MonoBehaviour
{

    void OnPointerDown()
    {
        RestartScene();
    }
    void OnMouseDown()
    {
        RestartScene();
    }
    public void RestartScene()
    {
        //Application.LoadLevel(Application.loadedLevel);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

}

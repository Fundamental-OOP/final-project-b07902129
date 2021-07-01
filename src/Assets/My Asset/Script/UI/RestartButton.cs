using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : AButton {
    public override void OnPointerDown(PointerEventData data) {
        Restart();
    }
    public override void OnPointerUp(PointerEventData data) {
        pressed = false;
    }
    public override void onClick() {}

    private void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
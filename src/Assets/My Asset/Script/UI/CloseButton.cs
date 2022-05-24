using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CloseButton : AButton {
    public override void OnPointerDown(PointerEventData data) {
        Close();
    }
    public override void OnPointerUp(PointerEventData data) {
        pressed = false;
    }
    public override void onClick() {}

    private void Close() {
        Application.Quit();
    }

}
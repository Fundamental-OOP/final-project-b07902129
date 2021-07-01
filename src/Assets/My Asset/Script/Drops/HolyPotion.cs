using UnityEngine;
public class HolyPotion : Drops {
    public ACanvas win;
    void Awake() {
        win = GameObject.Find("WinUI").GetComponent<ACanvas>();
    }
    override public void SingleUse()
    {
        win.ActivateCanvas();
    }
}
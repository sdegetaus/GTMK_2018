using UnityEngine;

public enum ClickType {
    Test01, Test02
}

public class GUIClickEvent : MonoBehaviour {

    public ClickType clickType;

    private float clickDelay = 0.2f;
    private float lastClickTime = -0.2f;

    public bool CanClick() {
        bool canClickTime = lastClickTime + clickDelay < Time.time;
        lastClickTime = Time.time;
        return canClickTime;
    }

    public void OnClick() {
        if (!Application.isPlaying || !CanClick()) {
            return;
        }

        //switch (clickType) {
                
        //}
    }
}
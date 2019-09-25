using UnityEngine;

public enum ClickType {

    // General: 0 - 99
    GoToPreviousGUIState = 0,

    // MainMenu: 100 - 199
    StartRun = 100,

    // Settings: 200 - 299

    // InGame: 300 - 399
    PauseRun = 350,
    ResumeRun = 351,

    // RunOver: 400 - 499
    BackToMainMenu = 400,
    Replay = 405,

    // Settings: 500 - 599

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

        if (!Application.isPlaying || !CanClick()) return;

        switch (clickType) {

            // General: 0 - 99

            case ClickType.GoToPreviousGUIState:
                GUIManager.instance.ChangeToPreviousState();
                break;

            default:
                Debug.LogError("ClickType " + clickType + " not implemented!");
                break;

            // MainMenu: 100 - 199

            case ClickType.StartRun:
                Events.instance.OnRunStarted.Raise();
                break;

            // InGame: 300 - 399

            case ClickType.PauseRun:
                Events.instance.OnRunPaused.Raise();
                break;

            case ClickType.ResumeRun:
                Events.instance.OnRunResumed.Raise();
                break;

        }
    }
}
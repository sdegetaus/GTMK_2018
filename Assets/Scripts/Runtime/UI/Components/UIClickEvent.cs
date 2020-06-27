using UnityEngine;

namespace GMTK
{
    public class UIClickEvent : MonoBehaviour
    {
        public enum ClickType
        {
            Undefined = -1,

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
            RestartRun = 405,

            // Settings: 500 - 599
        }

        [SerializeField]
        private ClickType clickType = ClickType.Undefined;

        public void OnClick()
        {
            switch (clickType)
            {

                default:
                    Debug.LogError("ClickType " + clickType + " not implemented!");
                    break;

                // General: 0 - 99

                case ClickType.GoToPreviousGUIState:
                    UIManager.PreviousState();
                    break;

                // MainMenu: 100 - 199

                case ClickType.StartRun:
                    GameManager.Events.OnRunStarted.Raise();
                    break;

                // InGame: 300 - 399

                case ClickType.PauseRun:
                    GameManager.Events.OnRunPaused.Raise();
                    break;

                case ClickType.ResumeRun:
                    GameManager.Events.OnRunResumed.Raise();
                    break;

                // RunOver: 400 - 499

                case ClickType.RestartRun:
                    GameManager.Events.OnRunStarted.Raise();
                    break;

            }
        }
    }
}
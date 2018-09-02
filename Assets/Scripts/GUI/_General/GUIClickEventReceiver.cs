using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace XXXGame.GUI
{
    public enum ClickType
    {
        ToMenuFromAbout, ToMenuFromPause, ToMenuFromGameOver, PauseGame, Replay, Resume, StartGame, About,

        // Social
        ToSantiago, ToPaco, ToArturo, ToAndres, ToRaquel

    }

    public class GUIClickEventReceiver : MonoBehaviour
    {
        public ClickType clickType;

        private float clickDelay = 0.2f;
        private float lastClickTime = -0.2f;

        public bool CanClick()
        {
            bool canClickTime = lastClickTime + clickDelay < Time.time;
            lastClickTime = Time.time;
            return canClickTime;
        }

        public void OnClick()
        {
            if (!Application.isPlaying || !CanClick()) {
                return;
            }

            switch (clickType) {
                case ClickType.ToMenuFromAbout:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
                case ClickType.ToMenuFromPause:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
                case ClickType.ToMenuFromGameOver:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
                case ClickType.PauseGame:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.Pause);
                    break;
                case ClickType.Replay:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
                    break;
                case ClickType.Resume:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
                    break;
                case ClickType.StartGame:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
                    break;
                case ClickType.About:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.About);
                    break;
                case ClickType.ToSantiago:
                    Application.OpenURL("http://taus.mx");
                    break;
                case ClickType.ToPaco:
                    break;
                case ClickType.ToArturo:
                    Application.OpenURL("https://www.instagram.com/arturo_rivera.s/");
                    break;
                case ClickType.ToAndres:
                    Application.OpenURL("https://www.instagram.com/apaulmusic/");
                    break;
                case ClickType.ToRaquel:
                    break;
            }
        }
    }
}
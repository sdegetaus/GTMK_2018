using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using XXXGame.Gameplay;

namespace XXXGame.GUI
{
    public enum ClickType
    {
        ToMenuFromAbout, ToMenuFromPause, ToMenuFromGameOver, PauseGame, Replay, Resume, StartGame, About,

        // Social
        ToSantiago, ToPaco, ToArturo, ToAndres, ToRaquel,

        CloseGame

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
                    AmbientManager.instance.UpdateShaderValues(true);
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
                case ClickType.ToMenuFromPause:
                    GameManager.instance.StopGame();
                    AmbientManager.instance.UpdateShaderValues(true);
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    GameManager.instance.ResumeGame();
                    ElementSpawner.instance.continueSpawning = false;
                    PlayerController.instance.ResetEvents();
                    PlayerController.instance.Deactivate();
                    break;
                case ClickType.ToMenuFromGameOver:
                    AmbientManager.instance.UpdateShaderValues(true);
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
                case ClickType.PauseGame:
                    AmbientManager.instance.UpdateShaderValues(true);
                    GUIStateMachine.instance.ChangeGUIState(GUIState.Pause);
                    GameManager.instance.PauseGame();
                    break;
                case ClickType.Replay:
                    GameManager.instance.Replay();
                    break;
                case ClickType.Resume:
                    AmbientManager.instance.UpdateShaderValues(false);
                    GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
                    GameManager.instance.ResumeGame();
                    break;
                case ClickType.StartGame:
                    GameManager.instance.StartGame();
                    break;
                case ClickType.About:
                    AmbientManager.instance.UpdateShaderValues(true);
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
                case ClickType.CloseGame:
                    GameManager.instance.QuitGame();
                    break;
                    
            }
        }
    }
}
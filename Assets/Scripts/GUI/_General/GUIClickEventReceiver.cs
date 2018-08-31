using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace XXXGame.GUI
{
    public enum ClickType
    {
        Prueba, Prueba2
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
                case ClickType.Prueba:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
                    break;
                case ClickType.Prueba2:
                    GUIStateMachine.instance.ChangeGUIState(GUIState.MainMenu);
                    break;
            }
        }
    }
}
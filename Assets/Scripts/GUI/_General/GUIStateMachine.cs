using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XXXGame.GUI
{
    public enum GUIState { MainMenu, InGame, MaxGUIState }

    public class GUIStateMachine : MonoBehaviour {

        static public GUIStateMachine instance;
        public Canvas[] canvases = new Canvas[(int)GUIState.MaxGUIState - 1];
        public GUIState LastState {
            get {
                return lastState;
            }
        }

        private GUIState guiState = GUIState.MainMenu;
        private GUIState lastState = GUIState.MainMenu;

        public void Awake() {
            instance = this;
            foreach (Canvas canvas in canvases) {
                if (canvas != null) {
                    DontDestroyOnLoad(canvas);
                }
            }
        }

        public void Start() {
            ShowCanvas(GUIState.MainMenu, show: true);
            for (GUIState i = GUIState.MainMenu + 1; i < GUIState.MaxGUIState; i++) {
                ShowCanvas(i, show: false);
            }
        }

        public void ChangeGUIState(GUIState state) {
            if (state == guiState) {
                return;
            }
            ShowCanvas(guiState, false);
            ShowCanvas(state, true);
            lastState = guiState;
            guiState = state;
        }

        public void ShowCanvas(GUIState state, bool show) {

            if ((int)state >= canvases.Length) {
                Debug.LogError("Enlarge array of canvases in Game Inspector");
                return;
            }

            if (canvases[(int)state] == null) {
                Debug.LogError("Assign canvas to array of canvases in Game Inspector");
                return;
            }

            //Debug.Log("Gui State " + state.ToString() + " is " + (show ? " shown." : "hidden."));
            CanvasLogic canvasLogic = canvases[(int)state].gameObject.GetComponent<CanvasLogic>();

            // we are hiding the canvas
            if (show == false && canvasLogic != null) {
                canvasLogic.OnLeave();
            }

            canvases[(int)state].gameObject.SetActive(show);

            if (show == true && canvasLogic != null) {
                canvasLogic.OnEnter();
            }
        }
    }
}
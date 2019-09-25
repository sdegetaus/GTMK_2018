using UnityEngine;
using System.Collections.Generic;

public class GUIManager : Singleton<GUIManager> {

    [Header("GUI State"), SerializeField]
    private GUIState currentState, lastState = GUIState.MainMenu;

    [Header("Canvases"), SerializeField]
    private List<CanvasLogic> canvases = new List<CanvasLogic>();

    [Space, SerializeField]
    private bool isAdditive = false;

    private void Start() {

        // make sure the main menu canvas is shown first
        ShowCanvas(GUIState.MainMenu, true);

        // make sure all the other canvases are hidden
        for (GUIState i = GUIState.MainMenu + 1; i < GUIState.MaxGUIState; i++) {
            ShowCanvas(i, false);
        }

    }

    private void ShowCanvas(GUIState state, bool show) {

        if ((int)state >= canvases.Count) {
            Debug.LogError("Enlarge array of canvases in the Game Inspector");
            return;
        }

        if (canvases[(int)state] == null) {
            Debug.LogError("Assign canvas to array of canvases in Game Inspector");
            return;
        }

        CanvasLogic canvasLogic = canvases[(int)state];

        // call the onLeave method within the canvasLogic child
        if (show == false) canvasLogic.OnLeave();

        // make sure the gameobject is active
        canvasLogic.gameObject.SetActive(true);

        // we are hiding the canvas
        canvasLogic.canvas.enabled = show;

        // finally call the onEnter method within the enabled canvasLogic
        if (show == true) canvasLogic.OnEnter();
    }

    public void ChangeGUIState(GUIState toState) {

        // if already on the same state, return
        if (toState == currentState) return;

        if (isAdditive) {
            HideAllCanvases();
            // revert canvas order
            canvases[(int)currentState].canvas.sortingOrder -= 1;
            isAdditive = false;
        }

        if (Consts.debugGUIChange) {
            Debug.LogFormat("Change GUIState from {0} to {1}.", currentState, toState);
        }

        // hide previous state
        ShowCanvas(currentState, false);

        // show new one
        ShowCanvas(toState, true);

        lastState = currentState;
        currentState = toState;

    }

    #region ChangeGUIState Overloads

    public void ChangeGUIState(GUIState toState, ChangeGUIStateMode mode, bool inFront = true) {

        // same state, return
        if (toState == currentState) return;

        // if the mode is equal to Single,
        // then switch to the first overload of this method (see above)
        if (mode == ChangeGUIStateMode.Single) {
            ChangeGUIState(toState);
            return;
        }

        if (Consts.debugGUIChange) {
            Debug.LogFormat("Change GUIState from {0} to {1} additively.", currentState, toState);
        }

        if (inFront) canvases[(int)toState].canvas.sortingOrder = 1 + canvases[(int)lastState].canvas.sortingOrder;

        // Note: no need to hide the currentState
        // as this overload gets it merged

        // show new one
        ShowCanvas(toState, true);

        lastState = currentState;
        currentState = toState;

        isAdditive = true;
    }

    #endregion

    #region Public Methods

    public void HideAllCanvases() {
        for (GUIState i = GUIState.MainMenu; i < GUIState.MaxGUIState; i++) {
            ShowCanvas(i, false);
        }
    }

    public void HideCurrentCanvas() {
        ShowCanvas(currentState, false);
    }

    public void ChangeToPreviousState() {
        ChangeGUIState(lastState);
    }

    #endregion
}
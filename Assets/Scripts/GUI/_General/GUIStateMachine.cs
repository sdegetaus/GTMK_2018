using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GUIState {
    Test01,
    Test02,
    MaxGUIState
}

public class GUIStateMachine : MonoBehaviour {

    [SerializeField] private List<CanvasLogic> canvases = new List<CanvasLogic>();

    [SerializeField] private GUIState currentState = GUIState.Test01;
    [SerializeField] private GUIState lastState = GUIState.Test01;

    private void Start() {
        //ShowCanvas(GUIState.MainMenu, show: true);
        //for (GUIState i = GUIState.MainMenu + 1; i < GUIState.MaxGUIState; i++) {
        //    ShowCanvas(i, show: false);
        //}
    }

    //public void ChangeGUIState(GUIState state) {
    //    if (state == guiState) {
    //        return;
    //    }
    //    ShowCanvas(guiState, false);
    //    ShowCanvas(state, true);
    //    lastState = guiState;
    //    guiState = state;
    //}

    //public GUIState GetCurrentGUIState() {
    //    return guiState;
    //}

    //public void ShowCanvas(GUIState state, bool show) {

    //    if ((int)state >= canvases.Length) {
    //        Debug.LogError("Enlarge array of canvases in Game Inspector");
    //        return;
    //    }

    //    if (canvases[(int)state] == null) {
    //        Debug.LogError("Assign canvas to array of canvases in Game Inspector");
    //        return;
    //    }

    //    //Debug.Log("Gui State " + state.ToString() + " is " + (show ? " shown." : "hidden."));
    //    CanvasLogic canvasLogic = canvases[(int)state].gameObject.GetComponent<CanvasLogic>();

    //    // we are hiding the canvas
    //    if (show == false && canvasLogic != null) {
    //        canvasLogic.OnLeave();
    //    }

    //    canvases[(int)state].gameObject.SetActive(show);

    //    if (show == true && canvasLogic != null) {
    //        canvasLogic.OnEnter();
    //    }
    //}
}
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class GUIManager : Singleton<GUIManager> {

    [Header("GUI State"), SerializeField]
    private GUIState currentState, lastState = GUIState.MainMenu;

    [SerializeField]
    private List<CanvasLogic> canvases = new List<CanvasLogic>();

    [Space, SerializeField]
    private bool isAdditive = false;

    private void Start() {

        // make sure the main menu canvas is shown first
        ShowCanvas(GUIState.MainMenu, true, true);

        // make sure all the other canvases are hidden
        for (GUIState i = GUIState.MainMenu + 1; i < GUIState.MaxGUIState; i++) {
            ShowCanvas(i, false, false);
        }

    }

    private void ShowCanvas(GUIState state, bool show, bool fade, UnityAction onFadeFinished = null) {

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

        if (fade) {

            float alpha = 0f;
            LeanTweenType tweenType = LeanTweenType.easeInCubic;

            if (show) {
                alpha = 1f;
                tweenType = LeanTweenType.easeOutCubic;
            }

            LeanTween.alphaCanvas(canvasLogic.canvasGroup, alpha, 0.5f)
                .setOnComplete(() => {
                    // hiding the canvas
                    canvasLogic.canvas.enabled = show;
                    onFadeFinished?.Invoke();
                    Debug.Log((onFadeFinished != null) ? "Invoked" : "");
                })
                .setEase(tweenType);

        } else {
            // hiding the canvas
            canvasLogic.canvas.enabled = show;
        }


        // finally call the onEnter method within the enabled canvasLogic
        if (show == true) canvasLogic.OnEnter();
    }

    public void ChangeGUIState(GUIState toState, bool fade = true, UnityAction onFadeFinished = null) {

        // if already on the same state, return
        if (toState == currentState) return;

        if (isAdditive) {
            HideAllCanvases();
            isAdditive = false;
        }

        if (Consts.debugGUIChange) {
            Debug.LogFormat("Change GUIState from {0} to {1}.", currentState, toState);
        }

        // hide previous state
        ShowCanvas(currentState, false, fade);

        // show new one
        ShowCanvas(toState, true, fade, onFadeFinished);

        lastState = currentState;
        currentState = toState;

    }

    #region ChangeGUIState Overloads

    public void ChangeGUIState(GUIState toState, ChangeGUIStateMode mode, bool fade = true, UnityAction onFadeFinished = null) {

        // same state, return
        if (toState == currentState) return;

        // if the mode is equal to Single,
        // then switch to the first overload of this method (see above)
        if (mode == ChangeGUIStateMode.Single) {
            ChangeGUIState(toState, fade, onFadeFinished);
            return;
        }

        if (Consts.debugGUIChange) {
            Debug.LogFormat("Change GUIState from {0} to {1} additively.", currentState, toState);
        }

        //if (inFront) canvases[(int)toState].canvas.sortingOrder = 1 + canvases[(int)lastState].canvas.sortingOrder;

        // Note: no need to hide the currentState
        // as this overload gets it merged

        // show new one
        ShowCanvas(toState, true, fade, onFadeFinished);

        lastState = currentState;
        currentState = toState;

        isAdditive = true;
    }

    #endregion

    #region Public Methods

    public void HideAllCanvases() {
        for (GUIState i = GUIState.MainMenu; i < GUIState.MaxGUIState; i++) {
            ShowCanvas(i, false, false);
        }
    }

    public void HideCurrentCanvas() {
        ShowCanvas(currentState, false, false);
    }

    public void ChangeToPreviousState() {
        ChangeGUIState(lastState);
    }

    #endregion
}
using System.Collections.Generic;
using UnityEngine;

public sealed class UIManager : Singleton<UIManager>
{
    public static UIState CurrentState { get; private set; }

    public static UIState LastState { get; private set; }

    // Inspector Variables
    [SerializeField]
    private List<CanvasLogic> canvasReferences = new List<CanvasLogic>();

    [SerializeField]
    private List<CanvasLogic> canvasInstances = new List<CanvasLogic>();

    private void Start()
    {
        CurrentState = 0;
        LastState = 0;

        // initialize list to the enum size!
        // (we can then address it with !null checks)
        for (UIState i = (UIState)1; i < UIState.Empty; i++)
            canvasInstances.Add(null);

        // make sure the first canvas is shown first
        ShowCanvas(0, true);

#if UNITY_EDITOR
        // on the editor, set as child of this object
        canvasInstances[0].transform.SetParent(transform, false);
#endif
    }

    private void ShowCanvas(UIState state, bool show)
    {
        var canvasLogic = canvasInstances[(int)state];

        // null? instantiate!
        if (canvasLogic == null)
        {
            canvasInstances[(int)state] = Instantiate(canvasReferences[(int)state]);
#if UNITY_EDITOR
            // on the editor, set as child of this object
            canvasInstances[(int)state].transform.SetParent(transform, false);
#endif
            canvasLogic = canvasInstances[(int)state];
        }

        // call the onLeave method within the canvasLogic child
        if (show == false)
        {
            canvasLogic.canvas.sortingOrder = 0;
            canvasLogic.OnLeave();
        }

        // we are hiding the canvas
        canvasLogic.canvas.enabled = show;

        // setting is interactibility
        canvasLogic.canvasGroup.interactable = show;

        // important! set this to the same as ^^
        canvasLogic.canvasGroup.blocksRaycasts = show;

        // finally call the onEnter method within the enabled canvasLogic
        if (show == true)
        {
            canvasLogic.canvas.sortingOrder = 1;
            canvasLogic.OnEnter();
        }
    }

    public static void ChangeState
        (UIState toState, bool fade = true, bool forceChange = false)
    {
        // on the same state, return
        // except when forceChange is true
        if (forceChange == false &&
            toState == CurrentState)
        {
            return;
        }

        //if (fade) UIPersistent.CrossFade();

        // hide previous state
        Instance.ShowCanvas(CurrentState, false);

        // show new one
        Instance.ShowCanvas(toState, true);

        LastState = CurrentState;
        CurrentState = toState;
    }

    public static void HideAllCanvases()
    {
        // only hide instantiated canvases!
        for (UIState i = (UIState)0; i < UIState.Empty; i++)
        {
            if (Instance.canvasInstances[(int)i] == null) continue;
            Instance.ShowCanvas(i, false);
        }
        LastState = UIState.MainMenu;
        CurrentState = UIState.Empty;
    }

    public static void ResetFromHide()
    {
        CurrentState = LastState;
        LastState = UIState.Empty;
        Instance.ShowCanvas(CurrentState, true);
    }

    public static void PreviousState()
    {
        ChangeState(LastState);
    }

}
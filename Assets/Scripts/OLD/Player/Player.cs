using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Status")]
    public Lane lanePosition = Lane.Middle;
    public bool isMoving = false;

    [Header("Settings")]
    public float movementTransition;

    // Private Variables
    private LeanTweenType tweenType = LeanTweenType.easeOutQuad;
    private bool fromStart = false;

    // Class References
    private Events events;

    private void Start() {
        events = Events.instance;
        events.OnRunStarted.RegisterListener(OnRunStarted);
        events.OnRunOver.RegisterListener(OnRunOver);
    }

    #region Event Handlers

    private void OnRunStarted() {
        fromStart = true;
        Move(Lane.Middle);
    }

    private void OnRunOver() {
        LeanTween.cancel(gameObject);
        isMoving = false;
    }

    #endregion

    public void MoveLeft() {
        if (isMoving) return;
        Move(CheckLaneLimit(lanePosition - 1));
    }

    public void MoveRight() {
        if (isMoving) return;
        Move(CheckLaneLimit(lanePosition + 1));
    }
    
    private Lane CheckLaneLimit(Lane toLane) {
        if (toLane < 0) return lanePosition;
        if (toLane > Lane.Right) return lanePosition;
        return toLane;
    }

    private void Move(Lane toLane) {

        if (lanePosition == toLane && fromStart == false) return;

        float to = 0.0f;
        Lane newLanePosition = toLane;

        isMoving = true;

        switch (toLane) {
            case Lane.Left:
                to = Consts.laneSeparation;
                break;
            case Lane.Right:
                to = -Consts.laneSeparation;
                break;
            default:
                newLanePosition = Lane.Middle;
                break;
        }

        LeanTween.moveZ(gameObject, to, movementTransition)
            .setOnComplete(() => {
                gameObject.transform.position = gameObject.transform.position.With(z: to);
                lanePosition = newLanePosition;
                isMoving = false;
                fromStart = false;
            }
        ).setEase(tweenType);
    }
}

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

    private void Update() {

        if (isMoving || !GameManager.IsRunPlaying) return;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            MoveLeft();
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            MoveRight();
            return;
        }

    }

    private void MoveLeft() => Move(CheckLaneLimit(lanePosition - 1));

    private void MoveRight() => Move(CheckLaneLimit(lanePosition + 1));
    
    private Lane CheckLaneLimit(Lane toLane) {
        if (toLane < 0) return lanePosition;
        if (toLane > Lane.Right) return lanePosition;
        return toLane;
    }

    private void Move(Lane toLane) {

        if (lanePosition == toLane) return;

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
            }
        ).setEase(tweenType);
    }
}

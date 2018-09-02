using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BallState { Middle, Right, None, Left }

public class Ball : MonoBehaviour {

    //Inspector
    [Header("Time Controller:")]
    [SerializeField] private float ballStateChangeInterval;

    [Header("Arrows:")]
    [SerializeField] private Sprite[] lanePositionSprites;
    [SerializeField] private Image lanePositionImage;

    [Header("Countdown:")]
    [SerializeField] private Sprite[] countDownSprites;
    [SerializeField] private Image countDownImage;

    // Lane Constants
    private readonly Vector3 middleLane = Vector3.zero;
    private readonly Vector3 rightLane = new Vector3(0, 0, -1.6f);
    private readonly Vector3 leftLane = new Vector3(0, 0, 1.6f);

    // Transition Smoothness (entre más, más duro; menos: más suave)
    private const float smoothing = 3.0f;

    // State Registers
    private BallState nextBallState; // For signaling
    private BallState currentBallState; // The one in

    private void Start() {
        // Sprite Clear
        lanePositionImage.enabled = false;
        lanePositionImage.sprite = null;

        // Ball State Begin
        StartCoroutine(BeginInfiniteBallStateChange());
    }

    private IEnumerator BeginInfiniteBallStateChange() {
        while(true) {
            StartCoroutine(SetRandomBallPos());
            yield return new WaitForSeconds(ballStateChangeInterval);
        }
    }

    public IEnumerator SetRandomBallPos() {

        StartCoroutine(DoCountDown());

        // Setting Previous State
        currentBallState = nextBallState;

        // Setting Random State for Ball
        int rnd = Random.Range(0, 3);

        lanePositionImage.enabled = true;

        switch (rnd) {
            case 0:
                nextBallState = BallState.Middle;
                //lanePositionImage.sprite = lanePositionSprites[0];
                break;
            case 1:
                nextBallState = BallState.Right;
                //lanePositionImage.sprite = lanePositionSprites[1];
                break;
            case 2:
                nextBallState = BallState.Left;
                //lanePositionImage.sprite = lanePositionSprites[2];
                break;
            default:
                nextBallState = BallState.None;
                //lanePositionImage.enabled = false;
                //lanePositionImage.sprite = null;
                break;
        }

        // Checking if Rnd number wanted to move itself through two lanes: yes, set image and state to middle
        if ((currentBallState == BallState.Left && nextBallState == BallState.Right) || currentBallState == BallState.Right && nextBallState == BallState.Left) {
            if (currentBallState == BallState.Left && nextBallState == BallState.Right) {
                nextBallState = BallState.Middle;
                lanePositionImage.sprite = lanePositionSprites[1]; // Right Sprite
            } else { //if(currentBallState == BallState.Right && nextBallState == BallState.Left)
                nextBallState = BallState.Middle;
                lanePositionImage.sprite = lanePositionSprites[2]; // Left Sprite
            }
        } else if ((currentBallState == BallState.Left && nextBallState == BallState.Middle)) {
            lanePositionImage.sprite = lanePositionSprites[1]; // Arrow Right
        } else if ((currentBallState == BallState.Right && nextBallState == BallState.Middle)) {
            lanePositionImage.sprite = lanePositionSprites[2]; // Arrow Left
        } else {
            if((currentBallState == BallState.Middle && nextBallState == BallState.Left)) {
                lanePositionImage.sprite = lanePositionSprites[2];
            } else if((currentBallState == BallState.Middle && nextBallState == BallState.Right)){
                lanePositionImage.sprite = lanePositionSprites[1];
            } else if(currentBallState ==  nextBallState) {
                lanePositionImage.sprite = lanePositionSprites[0];
            }
        }

        //Debug.Log("1. Current: " + currentBallState + "; Next: " + nextBallState);

        //countDownImage.enabled = true;
        //countDownImage.sprite = countDownSprites[0];

        yield return new WaitForSeconds(ballStateChangeInterval);
        //StartCoroutine(DoCountDown());
        //Debug.Log(DoCountDown().Current);
        //yield return new WaitUntil(() => DoCountDown().Current == null);
        //Debug.Log(DoCountDown().Current);
        //Debug.Log(DoCountDown().Current);

        //yield return StartCoroutine(DoCountDown());

        //StartCoroutine(DoCountDown());

        // Sprite Clear
        //lanePositionImage.enabled = false;
        //yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveBall(nextBallState));
    }

    private IEnumerator DoCountDown() {
        for (int i = 0; i < countDownSprites.Length; i++) {
            countDownImage.sprite = countDownSprites[i];
            yield return new WaitForSeconds(ballStateChangeInterval / 3);
        }

        //Reset Values
        //countDownImage.enabled = false;
        //countDownImage.sprite = null;
    }

    private IEnumerator MoveBall(BallState lane) {
        Vector3 target = SetNextBallPos(lane);
        while (Vector3.Distance(transform.position, target) > 0.05f) {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
            yield return null;
        }
        currentBallState = lane;
        yield return new WaitForSeconds(ballStateChangeInterval);
    }

    private Vector3 SetNextBallPos(BallState state) {
        switch (state) {
            case BallState.Middle:
                return middleLane;
            case BallState.Right:
                return rightLane;
            case BallState.Left:
                return leftLane;
            case BallState.None:
                return middleLane;
            default:
                return middleLane;
        }
    }

    ////DEBUG
    //public void MoveLeft() {
    //    StartCoroutine(MoveBall(BallState.Left));
    //}

    //public void MoveRight() {
    //    StartCoroutine(MoveBall(BallState.Right));
    //}

    //public void MoveMiddle() {
    //    StartCoroutine(MoveBall(BallState.Middle));
    //}
}

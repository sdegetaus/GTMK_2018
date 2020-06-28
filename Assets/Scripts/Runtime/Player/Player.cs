using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK
{
    public class Player : MonoBehaviour
    {
        public static Lane CurrentLane = Lane.Middle;
        public static Lane PreviousLane = Lane.Middle;

        public Vector3 Position { get => gameObject.transform.position; }

        [SerializeField]
        private bool isMoving = false;

        [Header("Settings")]
        [SerializeField] private float movementTransition;

        [Header("Signaling")]
        [SerializeField] private Canvas signalingCanvas = null;
        [SerializeField] public Image arrowImage = null;

        // Private Variables
        private bool fromStart = false;
        private Assets assets = null;

        private void Start()
        {
            assets = Assets.Instance;
            signalingCanvas.enabled = false;

            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
            GameManager.Events.OnRunPaused.RegisterListener(OnRunPaused);
            GameManager.Events.OnRunResumed.RegisterListener(OnRunResumed);
        }

        #region Event Handlers

        private void OnRunStarted()
        {
            fromStart = true;
            Move(Lane.Middle);
            StartCoroutine(RandomWalker());
        }

        private void OnRunOver()
        {
            signalingCanvas.enabled = false;
            LeanTween.cancel(gameObject);
            isMoving = false;
            StopAllCoroutines();
        }

        private void OnRunPaused()
        {
            signalingCanvas.enabled = false;
            LeanTween.cancel(gameObject);
            isMoving = false;
            StopAllCoroutines();
        }

        private void OnRunResumed()
        {
            StartCoroutine(RandomWalker());
        }

        #endregion

        private IEnumerator RandomWalker()
        {
            signalingCanvas.enabled = true;
            while (true)
            {
                var newLane = CheckLaneLimit(CurrentLane + ((Random.value * 100f).HasChance() ? 1 : -1));
                ChangeArrowDirection(newLane);
                yield return new WaitForSeconds(1f);
                Move(newLane);
            }
        }


        private Lane CheckLaneLimit(Lane toLane)
        {
            if (toLane < 0) return CurrentLane;
            if (toLane > Lane.Right) return CurrentLane;
            return toLane;
        }

        private void Move(Lane toLane)
        {
            if (CurrentLane == toLane && fromStart == false)
            {
                return;
            }

            PreviousLane = CurrentLane;

            float to = 0.0f;
            var newLanePosition = toLane;

            isMoving = true;

            switch (toLane)
            {
                case Lane.Left:
                    to = Consts.LANE_SEPARATION;
                    break;
                case Lane.Right:
                    to = -Consts.LANE_SEPARATION;
                    break;
                default:
                    newLanePosition = Lane.Middle;
                    break;
            }

            LeanTween.moveZ(gameObject, to, movementTransition)
                .setOnComplete(() =>
                {
                    arrowImage.sprite = assets.arrowStraight;
                    gameObject.transform.position = gameObject.transform.position.With(z: to);
                    CurrentLane = newLanePosition;
                    isMoving = false;
                    fromStart = false;
                }
            ).setEase(LeanTweenType.easeOutQuad);
        }

        private void ChangeArrowDirection(Lane newLane)
        {
            if (newLane == PreviousLane)
                arrowImage.sprite = assets.arrowStraight;
            else if (newLane < PreviousLane)
                arrowImage.sprite = assets.arrowLeft;
            else
                arrowImage.sprite = assets.arrowRight;
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (GameManager.CanReadInput && Consts.DEBUG_PLAYER_MOV)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.A))
                {
                    MoveLeft();
                    return;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.D))
                {
                    MoveRight();
                    return;
                }
            }
        }

        private void MoveLeft()
        {
            if (isMoving) return;
            Move(CheckLaneLimit(CurrentLane - 1));
        }

        private void MoveRight()
        {
            if (isMoving) return;
            Move(CheckLaneLimit(CurrentLane + 1));
        }

#endif

    }
}
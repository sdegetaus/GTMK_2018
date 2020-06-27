using UnityEngine;
namespace GMTK
{
    public class Player : MonoBehaviour
    {
        [Header("Status")]
        public Lane lanePosition = Lane.Middle;
        public bool isMoving = false;

        [Header("Settings")]
        public float movementTransition;

        // Private Variables
        private LeanTweenType tweenType = LeanTweenType.easeOutQuad;
        private bool fromStart = false;

        public Vector3 Position { get => gameObject.transform.position; }

        private void Start()
        {
            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
        }

        #region Event Handlers

        private void OnRunStarted()
        {
            fromStart = true;
            Move(Lane.Middle);
        }

        private void OnRunOver()
        {
            LeanTween.cancel(gameObject);
            isMoving = false;
        }

        #endregion

        private void Update()
        {
            if (Consts.DEBUG_PLAYER_MOV && GameManager.CanReadInput)
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
            Move(CheckLaneLimit(lanePosition - 1));
        }

        private void MoveRight()
        {
            if (isMoving) return;
            Move(CheckLaneLimit(lanePosition + 1));
        }

        private Lane CheckLaneLimit(Lane toLane)
        {
            if (toLane < 0) return lanePosition;
            if (toLane > Lane.Right) return lanePosition;
            return toLane;
        }

        private void Move(Lane toLane)
        {
            if (lanePosition == toLane && fromStart == false) return;

            float to = 0.0f;
            Lane newLanePosition = toLane;

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
                    gameObject.transform.position = gameObject.transform.position.With(z: to);
                    lanePosition = newLanePosition;
                    isMoving = false;
                    fromStart = false;
                }
            ).setEase(tweenType);
        }
    }
}
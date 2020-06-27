using System.Collections;
using UnityEngine;
namespace GMTK
{
    public class Player : MonoBehaviour
    {
        public Vector3 Position
        {
            get => gameObject.transform.position;
        }

        [SerializeField]
        private Lane currentLane = Lane.Middle;

        [SerializeField]
        private bool isMoving = false;

        [Header("Settings")]
        [SerializeField]
        private float movementTransition;

        // Private Variables
        private LeanTweenType tweenType = LeanTweenType.easeOutQuad;
        private bool fromStart = false;

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
            StartCoroutine(RandomWalker());
        }

        private void OnRunOver()
        {
            LeanTween.cancel(gameObject);
            isMoving = false;
            StopAllCoroutines();
        }

        #endregion

        private IEnumerator RandomWalker()
        {
            yield return new WaitForSeconds(1f);
            while (true)
            {
                var l = CheckLaneLimit(currentLane + (50f.HasChance() ? 1 : -1));
                Debug.Log(l);
                Move(l);
                yield return new WaitForSeconds(1f);
            }
        }

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
            Move(CheckLaneLimit(currentLane - 1));
        }

        private void MoveRight()
        {
            if (isMoving) return;
            Move(CheckLaneLimit(currentLane + 1));
        }

        private Lane CheckLaneLimit(Lane toLane)
        {
            if (toLane < 0) return currentLane;
            if (toLane > Lane.Right) return currentLane;
            return toLane;
        }

        private void Move(Lane toLane)
        {
            if (currentLane == toLane &&
                fromStart == false)
            {
                return;
            }

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
                    gameObject.transform.position = gameObject.transform.position.With(z: to);
                    currentLane = newLanePosition;
                    isMoving = false;
                    fromStart = false;
                }
            ).setEase(tweenType);
        }
    }
}
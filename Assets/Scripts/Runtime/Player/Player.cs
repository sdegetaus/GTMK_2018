using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK
{
    public class Player : MonoBehaviour
    {
        public static Lane CurrentLane = Lane.Middle;

        public Vector3 Position
        {
            get => gameObject.transform.position;
            set => gameObject.transform.position = value;
        }

        [SerializeField]
        private bool isMoving = false;

        [Header("Settings")]
        [SerializeField] private float movementTransition;

        [Header("Signaling")]
        [SerializeField] private Canvas signalingCanvas = null;
        [SerializeField] public Image arrowImage = null;

        // Private Variables
        private Assets assets = null;

        //private bool fromStart = false;

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
            StartCoroutine(RandomWalker());
        }

        private void OnRunOver()
        {
            StopAllCoroutines();
            LeanTween.cancel(gameObject);
            signalingCanvas.enabled = false;
            isMoving = false;
        }

        private void OnRunPaused()
        {
            StopAllCoroutines();
            LeanTween.cancel(gameObject);
            signalingCanvas.enabled = false;
            isMoving = false;
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
                Lane toLane = GetRandomLane();

                ChangeArrowDirection(toLane);

                if (toLane == CurrentLane)
                {
                    yield return new WaitForSeconds(2.0f);
                    continue;
                }

                yield return new WaitForSeconds(2.0f);

                Move(toLane);

                while (isMoving) yield return null;
            }
        }

        private Lane GetRandomLane()
        {
            Lane newLane = CurrentLane + ((Random.value * 100f).HasChance() ? 1 : -1);
            if (Mathf.Abs((int)newLane + (int)CurrentLane) >= 2) return Lane.Middle;
            return newLane;
        }

        private void Move(Lane toLane)
        {
            isMoving = true;

            var to = -1 * (float)toLane * Consts.LANE_SEPARATION;
            LeanTween.moveZ(gameObject, to, movementTransition)
                .setOnComplete(() =>
                {
                    Position = Position.With(z: to);
                    CurrentLane = toLane;
                    isMoving = false;
                }
            ).setEase(
                LeanTweenType.easeOutQuad
            );
        }

        private void ChangeArrowDirection(Lane toLane)
        {
            if (toLane == CurrentLane)
                arrowImage.sprite = assets.arrowStraight;
            else if (toLane < CurrentLane)
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
            Move(CurrentLane - 1);
        }

        private void MoveRight()
        {
            if (isMoving) return;
            Move(CurrentLane + 1);
        }
#endif

    }
}
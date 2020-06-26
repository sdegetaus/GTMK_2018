using System.Collections;
using UnityEngine;

namespace GMTK
{
    public class CameraController : Singleton<CameraController>
    {
        [SerializeField] private new Camera camera = null;
        [SerializeField] private GameObject cameraHolder = null;

        [Header("Shake Properties")]
        [Range(0f, 1f)] public float shakeAmount = 0.2f;

        [Header("Tween Presets")]
        [SerializeField] private TweenPreset a = null;

        // Private Variables
        private Vector3 originalCameraPosition = default;

        private void Start()
        {
            originalCameraPosition = camera.transform.localPosition;
            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
        }


        #region Event Handlers

        private void OnRunStarted()
        {
            ZoomTo(
                target: Vector3.zero,
                time: a.time,
                zoom: 6.0f
            );
        }

        private void OnRunOver()
        {
            Shake();
            ZoomTo(
                target: GameManager.Player.Position.With(x: -7.0f, y: 0.5f),
                time: a.time,
                zoom: 3.0f
            );
        }

        #endregion

        public void Shake()
        {
            StopAllCoroutines();
            StartCoroutine(Instance.ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            float time = a.time;
            float endTime = Time.time + time;
            while (Time.time < endTime)
            {
                camera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeAmount;
                time -= Time.deltaTime;
                yield return null;
            }
            camera.transform.localPosition = originalCameraPosition;
        }

        public void ZoomTo(Vector3 target, float time, float zoom)
        {
            LeanTween.cancel(cameraHolder);
            LeanTween.move(cameraHolder, target, time).setEase(a.ease);
            LeanTween.value(camera.gameObject, camera.orthographicSize, zoom, time)
                .setOnUpdate(f => camera.orthographicSize = f
            ).setEase(a.ease);
        }
    }
}
using System.Collections;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

    [SerializeField]
    private new Camera camera = null;

    [Header("Shake Properties")]
    [Range(0f, 1f)]
    public float shakeAmount = 0.2f;

    [Header("Tween Presets"), SerializeField]
    private TweenPreset tween = null;

    // Private Variables
    private Vector3 originalCameraPosition = default;

    // Class References
    private Events events = null;

    private void Start() {
        originalCameraPosition = camera.transform.localPosition;

        events = Events.instance;

        events.OnRunStarted.RegisterListener(OnRunStarted);
        events.OnRunOver.RegisterListener(OnRunOver);
    }


    #region Event Handlers

    private void OnRunStarted() {
        ZoomTo(
            Vector3.zero.With(x: 10f),
            tween.time,
            6f
        );
    }

    private void OnRunOver() {
        Shake();
        ZoomTo(
            GameManager.instance.player.gameObject.transform.position.With(y: 0.5f),
            tween.time,
            3f
        );
    }

    #endregion

    public void Shake() {
        StopAllCoroutines();
        StartCoroutine(
            instance.ShakeCoroutine()
        );
    }

    private IEnumerator ShakeCoroutine() {
        float time = tween.time;
        float endTime = Time.time + time;
        while (Time.time < endTime) {
            camera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeAmount;
            time -= Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalCameraPosition;
    }

    // TODO:
    public void ZoomTo(Vector3 target, float time, float zoom) {
        LeanTween.move(gameObject, target, time).setEase(tween.tweenType);
        LeanTween.value(camera.gameObject, camera.orthographicSize, zoom, time)
            .setOnUpdate((float flt) => {
                camera.orthographicSize = flt;
            }
        ).setEase(tween.tweenType);
    }
}
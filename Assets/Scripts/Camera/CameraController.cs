using System.Collections;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

    [SerializeField]
    private new Camera camera = null;

    [Header("Shake Properties")]

    [Range(0f, 1f)]
    public float duration = 0.5f;

    [Range(0f, 1f)]
    public float amount = 0.2f;

    // Private Variables
    private Vector3 originalCameraPosition = default;
    public LeanTweenType tweenType = LeanTweenType.notUsed;

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
        ZoomTo(Vector3.zero.With(x: 10f), 0.25f, 6f);
    }

    private void OnRunOver() {
        Shake();
        ZoomTo(
            GameManager.instance.player.gameObject.transform.position.With(y: 0.5f),
            0.25f,
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
        float _duration = duration;
        float endTime = Time.time + duration;
        while (Time.time < endTime) {
            camera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * amount;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalCameraPosition;
        duration = _duration;
    }

    // TODO:
    public void ZoomTo(Vector3 target, float time, float zoom) {
        LeanTween.move(gameObject, target, time).setEase(tweenType);
        LeanTween.value(camera.gameObject, camera.orthographicSize, zoom, time)
            .setOnUpdate((float flt) => {
                camera.orthographicSize = flt;
            }
        ).setEase(tweenType);
    }
}
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
    private Vector3 originalPosition = default;
    public LeanTweenType tweenType = LeanTweenType.notUsed;

    // Class References
    private Events events = null;

    private void Start() {
        originalPosition = camera.transform.localPosition;

        events = Events.instance;

        events.OnRunOver.RegisterListener(OnRunOver);
    }

    #region Event Handlers

    private void OnRunOver() {
        Shake();
        //ZoomTo(Vector3.zero, 0.25f, 4f);
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
            camera.transform.localPosition = originalPosition + Random.insideUnitSphere * amount;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.transform.localPosition = originalPosition;
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
using System.Collections;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

    [SerializeField]
    private new Camera camera = null;

    [Header("Shake Properties")]

    [Range(0f, 1f)]
    public float duration;

    [Range(0f, 1f)]
    public float amount;

    public LeanTweenType tweenType;

    // Private Variables
    private Vector3 originalPosition;

    private void Start() {
        originalPosition = camera.transform.localPosition;
    }

    public static void Shake() {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ShakeCoroutine());
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
    public static void ZoomTo(Vector3 target, float time, float zoom) {
        LeanTween.move(instance.gameObject, target, time).setEase(instance.tweenType);
        LeanTween.value(instance.camera.gameObject, instance.camera.orthographicSize, zoom, time)
            .setOnUpdate((float flt) => {
                instance.camera.orthographicSize = flt;
            }
        );
    }
}
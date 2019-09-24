using System.Collections;
using UnityEngine;

public class CameraController : Singleton<CameraController> {

    [Header("Shake Properties")]

    [Range(0f, 1f)]
    public float duration;

    [Range(0f, 1f)]
    public float amount;

    // Private Variables
    private Vector3 originalPosition;


    private void Start() {
        originalPosition = transform.localPosition;
    }

    public static void Shake() {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.ShakeCoroutine());
    }

    public IEnumerator ShakeCoroutine() {

        float _duration = duration;

        float endTime = Time.time + duration;

        while (Time.time < endTime) {
            transform.localPosition = originalPosition + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;

        duration = _duration;
    }
}
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIGraphicFlicker : MonoBehaviour
{
    [Header("Settings")]
    public float duration = 0.5f;
    public LeanTweenType tweenType = LeanTweenType.easeInOutBack;

    // Private Variables
    private RectTransform rect = null;

    private void OnEnable()
    {
        if (rect == null) rect = GetComponent<RectTransform>();
        LeanTween.textAlpha(rect, 0, duration)
            .setLoopPingPong()
            .setEase(tweenType);
    }

    private void OnDisable()
    {
        LeanTween.cancel(rect);
    }
}
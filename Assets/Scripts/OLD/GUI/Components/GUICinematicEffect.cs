using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICinematicEffect : MonoBehaviour {

    [SerializeField]
    private List<RectTransform> cinematicMasks = new List<RectTransform>();

    [Space]

    [SerializeField] private TweenPreset tween = null;

    public void FadeIn() {
        LeanTween.move(cinematicMasks[0], Vector3.zero, tween.time).setEase(tween.tweenType);
        LeanTween.move(cinematicMasks[1], Vector3.zero, tween.time).setEase(tween.tweenType);
    }

    public void FadeOut() {
        float to = cinematicMasks[0].rect.height;
        LeanTween.move(cinematicMasks[0], Vector3.zero.With(y: to), tween.time).setEase(tween.tweenType);
        LeanTween.move(cinematicMasks[1], Vector3.zero.With(y: -to), tween.time).setEase(tween.tweenType);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPersistent : CanvasLogic {

    [SerializeField]
    private List<RectTransform> cinematicMasks = new List<RectTransform>();

    public LeanTweenType tweenType;
    public float time;
    public float to;

    private void Start() {
        Events.instance.OnRunStarted.RegisterListener(OnRunStarted);
        Events.instance.OnRunOver.RegisterListener(OnRunOver);
    }

    private void OnRunStarted() {
        LeanTween.move(cinematicMasks[0], Vector3.zero.With(y: to), time).setEase(tweenType);
        LeanTween.move(cinematicMasks[1], Vector3.zero.With(y: -to), time).setEase(tweenType);
    }

    private void OnRunOver() {
        LeanTween.move(cinematicMasks[0], Vector3.zero, time).setEase(tweenType);
        LeanTween.move(cinematicMasks[1], Vector3.zero, time).setEase(tweenType);
    }

}
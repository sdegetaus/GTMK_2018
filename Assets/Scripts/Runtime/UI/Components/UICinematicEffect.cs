using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public class UICinematicEffect : MonoBehaviour
    {
        [SerializeField]
        private RectTransform topMask = null;

        [SerializeField]
        private RectTransform bottomMask = null;

        [Space]

        [SerializeField] private TweenPreset tween = null;

        public void FadeIn()
        {
            LeanTween.move(topMask, Vector3.zero, tween.time).setEase(tween.ease);
            LeanTween.move(bottomMask, Vector3.zero, tween.time).setEase(tween.ease);
        }

        public void FadeOut()
        {
            float to = topMask.rect.height;
            LeanTween.move(topMask, Vector3.zero.With(y: to), tween.time).setEase(tween.ease);
            LeanTween.move(bottomMask, Vector3.zero.With(y: -to), tween.time).setEase(tween.ease);
        }
    }
}
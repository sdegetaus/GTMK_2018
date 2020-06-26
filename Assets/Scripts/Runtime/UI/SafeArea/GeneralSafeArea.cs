using UnityEngine;

namespace BusyBytes
{

    [RequireComponent(typeof(RectTransform))]
    public sealed class GeneralSafeArea : SafeArea
    {

        [Header("Properties")]
        public bool AffectAnchorMinY = true;
        public bool AffectAnchorMaxY = true;

        protected override void ApplySafeArea()
        {

            Vector2 anchorMin = Screen.safeArea.position;
            Vector2 anchorMax = Screen.safeArea.position + Screen.safeArea.size;

            anchorMin.x = 0;
            anchorMax.x = 1.0f;

            anchorMin.y = (AffectAnchorMinY) ? anchorMin.y / Screen.height : 0;
            anchorMax.y = (AffectAnchorMaxY) ? anchorMax.y / Screen.height : 0;

            Panel.anchorMin = anchorMin;
            Panel.anchorMax = anchorMax;
        }

    }
}
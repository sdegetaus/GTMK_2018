using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BusyBytes
{
    public abstract class SafeArea : MonoBehaviour
    {

        protected RectTransform Panel = null;

        private void Awake()
        {
            Panel = GetComponent<RectTransform>();
            ApplySafeArea();
        }

        protected virtual void ApplySafeArea() { }

    }
}
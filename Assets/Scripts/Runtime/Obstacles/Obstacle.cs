using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTK
{
    public class Obstacle : MonoBehaviour, ICollide, ISelectable
    {
        private new List<Renderer> renderer;
        public TweenPreset a = null;

        public bool IsSelected = false;

        private void Start()
        {
            renderer = GetComponentsInChildren<Renderer>().ToList();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (GameManager.GodMode) return;
            GameManager.Events.OnRunOver.Raise();
        }

        public void OnClick()
        {
            if (!IsSelected)
               Select();
            else
                Deselect();
        }

        public void Select()
        {
            LeanTween.cancel(gameObject);
            if (IsSelected) return;
            LeanTween.moveY(gameObject, a.to, a.time).setEase(a.ease);
            IsSelected = true;
        }

        public void Deselect()
        {
            LeanTween.cancel(gameObject);
            if (!IsSelected) return;
            LeanTween.moveY(gameObject, 0, a.time / 2f).setEase(a.ease);
            IsSelected = false;
        }

    }
}
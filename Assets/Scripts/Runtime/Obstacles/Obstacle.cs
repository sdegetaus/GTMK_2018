using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTK
{
    public class Obstacle : MonoBehaviour, ICollide, ISelectable
    {
        private new List<Renderer> renderer;
        private ObstacleGroup obstacleGroup = null;
        public TweenPreset a = null;

        public bool IsSelected = false;

        private void Start()
        {
            renderer = GetComponentsInChildren<Renderer>().ToList();
            obstacleGroup = gameObject.transform.parent.GetComponent<ObstacleGroup>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (GameManager.GodMode) return;
            GameManager.Events.OnRunOver.Raise();
        }

        public void OnClick()
        {
            LeanTween.cancel(gameObject);

            if (!IsSelected)
                Select();
            else
                Deselect();

            IsSelected = !IsSelected;
            Debug.Log(IsSelected);
        }

        public void Select()
        {
            LeanTween.moveY(gameObject, a.to, a.time).setEase(a.ease);
            Debug.Log("Select");
        }

        public void Deselect()
        {
            LeanTween.moveY(gameObject, 0, a.time / 2f).setEase(a.ease);
            Debug.Log("Select");
        }

    }
}
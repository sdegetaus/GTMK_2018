using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTK
{
    public class Obstacle : MonoBehaviour, ICollide, ISelectable
    {
        private new List<Renderer> renderer;
        private ObstacleGroup obstacleGroup = null;

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

        public void Select()
        {
            Debug.Log("Select");
        }

    }
}
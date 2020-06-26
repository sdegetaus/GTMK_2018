using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, ICollide
{
    [SerializeField]
    private new List<Renderer> renderer = new List<Renderer>();

    [SerializeField]
    private ObstacleGroup obstacleGroup = null;

    private void Start()
    {
        obstacleGroup = gameObject.transform.parent.GetComponent<ObstacleGroup>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (GameManager.GodMode) return;
        GameManager.Events.OnRunOver.Raise();
    }
}
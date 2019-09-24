using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroup : MonoBehaviour {

    [SerializeField]
    private List<Obstacle> obstacles = new List<Obstacle>();

    [SerializeField]
    private ObstacleEnum activeObstacleEnum;

    [Space]

    [SerializeField]
    private FloatVariable globalSpeed = null;


    private void Update() {
        transform.position = transform.position.With(
            x: transform.position.x + globalSpeed.value * Time.deltaTime
        );
    }

    public void Init() {
        UnactivateAll();
        SetRandomObstacle();
    }

    private void SetActiveObstacle(ObstacleEnum obstacle) {
        obstacles[(int)obstacle].gameObject.SetActive(true);
        activeObstacleEnum = obstacle;
    }

    private void SetRandomObstacle() {
        SetActiveObstacle(Helper.GetRandomEnum<ObstacleEnum>());
    }

    private void UnactivateAll() {
        foreach (Obstacle obstacle in obstacles) {
            obstacle.gameObject.SetActive(false);
        }
    }

}

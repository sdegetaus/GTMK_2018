using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroup : MonoBehaviour {

    [SerializeField]
    private List<Obstacle> obstacles = new List<Obstacle>();

    [SerializeField]
    private ObstacleEnum activeObstacleEnum;

    public bool move = false;

    [Space]

    [SerializeField]
    private FloatVariable globalSpeed;

    private ObstacleMover obstacleMover;

    private void Start() {
        obstacleMover = GetComponent<ObstacleMover>();
    }

    private void Update() {

        Vector3 x = transform.position.With(
            x: transform.position.x + globalSpeed.value * Time.deltaTime
        );

        transform.position = x;
    }

    public void Init() {
        UnactivateAll();
        SetRandomObstacle();
        move = true;
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

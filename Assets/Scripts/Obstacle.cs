using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleEnum {
    Single,
    Double
}

public class Obstacle : MonoBehaviour {
    [SerializeField] private ObstacleEnum obstacleEnum;
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Variables")]
    public FloatVariable globalSpeed = null;
    public RandomFloatVariable obstacleSpawnYieldTime = null;

    [Header("Class References")]
    public Pooler pooler;
    public ObstacleManager obstacleManager;
    public ArrowsManager arrowsManager;

    private void Awake() {
        instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start() {
        StartRun();
    }

    public void StartRun() {
        pooler.InitializePool(() => {
            obstacleManager.ObstacleSpawning(pooler);
            arrowsManager.ArrowsSpawning(pooler);
        });
    }

}
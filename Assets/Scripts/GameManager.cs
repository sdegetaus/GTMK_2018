using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Variables")]
    public FloatVariable globalSpeed;
    public FloatVariable obstacleSpawnYieldTime;

    [Header("Class References")]
    public Pooler pooler;
    public ObstacleManager obstacleManager;

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
        });
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

    // Static Variables
    public static bool IsRunPlaying = false;

    [Header("Variables")]
    public FloatVariable runScore = null;
    public FloatVariable globalSpeed = null;
    public RandomFloatVariable obstacleSpawnYieldTime = null;

    [Header("Class References")]
    public Pooler pooler = null;
    public Spawner spawner = null;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    private void Start() {
        StartRun();
    }

    public void StartRun() {
        pooler.InitializePool(() => {
            spawner.BeginSpawning(pooler);
            IsRunPlaying = true;
        });
    }

    public void RunOver() {
        CameraController.Shake();
        IsRunPlaying = false;
        spawner.StopSpawning();
    }

    public void CollectibleCollected(CollectibleEnum collectibleEnum) {
        Debug.Log("Collectible Collected! " + collectibleEnum);
    }

}
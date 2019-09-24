using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static bool IsRunPlaying = false;

    [Header("Variables")]
    public FloatVariable runScore = null;
    public FloatVariable globalSpeed = null;
    public RandomFloatVariable obstacleSpawnYieldTime = null;

    [Header("Class References")]
    public Pooler pooler;
    public Spawner spawner;

    private void Awake() {
        instance = this;
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

    private void Update() {
        runScore.value += Time.deltaTime;
    }

    public void RunOver() {
        IsRunPlaying = false;
        spawner.StopSpawning();
    }

    public void CollectibleCollected(CollectibleEnum collectibleEnum) {
        Debug.Log("Collectible Collected! " + collectibleEnum);
    }

}
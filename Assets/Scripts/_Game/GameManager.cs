using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : Singleton<GameManager> {

    // Static Variables
    public static bool IsRunPlaying = false;
    public static bool IsRunPaused = false;

    [Header("Variables")]
    public FloatVariable runScore = null;
    public FloatVariable globalSpeed = null;
    public RandomFloatVariable obstacleSpawnYieldTime = null;

    [Header("Class References")]
    public Pools pools = null;
    public Spawner spawner = null;

    // Private Variables
    private Events events = null;
    private GUIManager guiManager = null;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    private void Start() {

        events = Events.instance;
        guiManager = GUIManager.instance;

        // register listeners
        events.OnRunStarted.RegisterListener(OnRunStarted);
        events.OnRunOver.RegisterListener(OnRunOver);
        events.OnRunPaused.RegisterListener(OnRunPaused);
        events.OnRunResumed.RegisterListener(OnRunResumed);

        // initialize pool (instantiate gameobjects)
        pools.InitializePool();
    }

    #region Event Handlers

    private void OnRunStarted() {
        guiManager.ChangeGUIState(GUIState.InGame);
        spawner.StartSpawning();
        IsRunPlaying = true;
    }

    private void OnRunOver() {
        guiManager.ChangeGUIState(GUIState.RunOver);
        IsRunPlaying = false;
    }

    private void OnRunPaused() {

        if (IsRunPaused) {
            Debug.Log("Can't pause the game as it is already paused!");
            return;
        }

        guiManager.ChangeGUIState(GUIState.Pause);
        IsRunPaused = true;
        Time.timeScale = 0;

    }

    private void OnRunResumed() {

        if (!IsRunPaused) {
            Debug.Log("Can't resume from pause as it the game is already running!");
            return;
        }

        guiManager.ChangeGUIState(GUIState.InGame);
        IsRunPaused = false;
        Time.timeScale = 1;

    }

    #endregion

    // TODO:
    public void CollectibleCollected(CollectibleEnum collectibleEnum) {
        Debug.Log("Collectible Collected! " + collectibleEnum);
    }

}
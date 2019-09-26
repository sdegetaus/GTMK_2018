using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : Singleton<GameManager> {

    // Static Variables
    public static bool IsRunPlaying = false;

    [Header("Variables")]
    public FloatVariable runScore = null;
    public FloatVariable globalSpeed = null;
    public FloatVariable obstacleSpawnYieldTime = null;

    [Header("Class References")]
    public Pools pools = null;
    public Spawner spawner = null;
    public Player player = null;

    // Private Variables
    private Events events = null;
    private GUIManager guiManager = null;

    private float m_globalSpeed;

    private void Awake() {
        Application.targetFrameRate = 60;
        obstacleSpawnYieldTime.value = Consts.initialObstacleSpawnYieldTime;
        globalSpeed.value = Consts.initialGlobalSpeed;
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
        IsRunPlaying = true;
    }

    private void OnRunOver() {
        guiManager.ChangeGUIState(GUIState.RunOver, false);
        IsRunPlaying = false;
    }

    private void OnRunPaused() {

        if (!IsRunPlaying) {
            Debug.Log("Can't pause the game as it is already paused!");
            return;
        }

        guiManager.ChangeGUIState(GUIState.Pause, false);

        m_globalSpeed = globalSpeed.value;
        globalSpeed.value = 0;

        spawner.StopSpawning();
        IsRunPlaying = false;
    }

    private void OnRunResumed() {

        if (IsRunPlaying) {
            Debug.Log("Can't resume from pause as it the game is already running!");
            return;
        }

        guiManager.ChangeGUIState(GUIState.InGame, false);


        globalSpeed.value = m_globalSpeed;
        m_globalSpeed = 0;

        spawner.StartSpawning(true);
        IsRunPlaying = true;
    }

    #endregion

    // TODO:
    public void CollectibleCollected(CollectibleEnum collectibleEnum) {
        Debug.Log("Collectible Collected!");
    }

}
using System;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {

    [SerializeField]
    private FloatVariable runScore;

    private void Start() {
        Events.instance.OnRunStarted.RegisterListener(OnRunStarted);
    }

    #region Events Handlers

    private void OnRunStarted() {
        runScore.value = 0;
    }

    #endregion

    private void Update() {

        if (!GameManager.IsRunPlaying) return;
        runScore.value += Time.deltaTime * 10;

    }
}
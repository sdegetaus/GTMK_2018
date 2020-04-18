using UnityEngine;

public class ScoreUpdater : MonoBehaviour {

    private FloatVariable runScore = null;

    private void Start() {
        runScore = GameManager.instance.runScore;
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
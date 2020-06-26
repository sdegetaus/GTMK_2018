using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private FloatVariable runScore = null;

    private void Start()
    {
        runScore = Assets.Instance.Score;
        GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
    }

    #region Events Handlers

    private void OnRunStarted()
    {
        runScore.value = 0;
    }

    #endregion

    private void Update()
    {
        if (!GameManager.IsRunPlaying) return;
        runScore.value += Time.deltaTime * 10;
    }
}
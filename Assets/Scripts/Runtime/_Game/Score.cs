using System.Collections;
using UnityEngine;

namespace GMTK
{
    public sealed class Score : MonoBehaviour
    {
        private FloatVariable score = null;
        private FloatVariable speed = null;

        private void Start()
        {
            score = Assets.Instance.Score;
            speed = Assets.Instance.Speed;

            score.value = 0;

            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
            GameManager.Events.OnRunPaused.RegisterListener(OnRunPaused);
            GameManager.Events.OnRunResumed.RegisterListener(OnRunResumed);
        }

        #region Event Handlers

        private void OnRunStarted()
        {
            score.value = 0;
            StartCoroutine(ScoreUpdate());
        }

        private void OnRunOver()
        {
            StopAllCoroutines();
            HandleScoreSave();
        }

        private void OnRunPaused()
        {
            StopAllCoroutines();
        }

        private void OnRunResumed()
        {
            StartCoroutine(ScoreUpdate());
        }

        #endregion

        #region Application Events

        private void OnApplicationPause(bool resume)
        {
            if (resume) HandleScoreSave();
        }

        #endregion

        private IEnumerator ScoreUpdate()
        {
            while (true)
            {
                score.value += Time.deltaTime * 10 * speed.value;
                yield return null;
            }
        }

        private void HandleScoreSave()
        {
            if (Prefs.Highscore < score.value)
            {
                Debug.Log($"<b>New Highscore! {score.value}</b>");
                Prefs.Highscore = score.value;
            }
        }

    }
}
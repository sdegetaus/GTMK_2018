using UnityEngine;

namespace GMTK
{
    public class ScoreUpdater : MonoBehaviour
    {
        private FloatVariable score = null;

        private void Start()
        {
            score = Assets.Instance.Score;
            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
        }

        #region Events Handlers

        private void OnRunStarted()
        {
            score.value = 0;
        }

        #endregion

        private void Update()
        {
            if (!GameManager.CanReadInput) return;
            score.value += Time.deltaTime * 10;
        }
    }
}
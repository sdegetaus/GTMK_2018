using UnityEngine;

namespace GMTK
{
    public class CanvasPersistent : Singleton<CanvasPersistent>
    {
        [SerializeField]
        private UICinematicEffect cinematicEffect = null;

        private void Start()
        {
            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
            GameManager.Events.OnRunPaused.RegisterListener(OnRunPaused);
            GameManager.Events.OnRunResumed.RegisterListener(OnRunResumed);
        }

        #region Event Handlers

        private void OnRunStarted()
        {
            cinematicEffect.FadeOut();
        }

        private void OnRunOver()
        {
            cinematicEffect.FadeIn();
        }

        private void OnRunPaused()
        {
            cinematicEffect.FadeIn();
        }

        private void OnRunResumed()
        {
            cinematicEffect.FadeOut();
        }

        #endregion

        public static void CinematicIn()
        {
            Instance.cinematicEffect.FadeIn();
        }

        public static void CinematicOut()
        {
            Instance.cinematicEffect.FadeOut();
        }

    }
}
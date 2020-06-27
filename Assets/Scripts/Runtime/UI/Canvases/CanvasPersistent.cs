using UnityEngine;

namespace GMTK
{
    public class CanvasPersistent : Singleton<CanvasPersistent>
    {
        [SerializeField]
        private UICinematicEffect cinematicEffect = null;

        private void Start()
        {
            GameManager.Events.OnRunStarted.RegisterListener(CinematicOut);
            GameManager.Events.OnRunOver.RegisterListener(CinematicIn);
            GameManager.Events.OnRunPaused.RegisterListener(CinematicIn);
            GameManager.Events.OnRunResumed.RegisterListener(CinematicOut);
        }

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
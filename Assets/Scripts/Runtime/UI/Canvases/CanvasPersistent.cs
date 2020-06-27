using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public class CanvasPersistent : CanvasLogic
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
    }
}
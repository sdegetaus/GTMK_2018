﻿using UnityEngine;
using UnityEngine.UI;

public class CanvasRunOver : CanvasLogic {

    [SerializeField]
    private GameObject deathScreen = null;

    [SerializeField]
    private GameObject runStats = null;

    [Space]

    [SerializeField]
    private Text runScoreText = null;

    [SerializeField]
    private FloatVariable runScore = null;

    private void OnEnable() {
        runScoreText.text = ((int)runScore.value).ToString("N0");
    }

    private void Start() {

        runStats.SetActive(false);
        deathScreen.SetActive(false);

        Events.instance.OnRunOver.RegisterListener(OnRunOver);
    }

    private void OnRunOver() {
        runStats.SetActive(false);
        deathScreen.SetActive(true);
    }
}
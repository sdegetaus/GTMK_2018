using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInGame : CanvasLogic {

    [SerializeField]
    private Text runScoreText;

    [SerializeField]
    private FloatVariable runScore;

    private void Update() {
        runScoreText.text = ((int)runScore.value).ToString("N0");
    }

}
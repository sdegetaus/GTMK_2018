using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInGame : CanvasLogic {

    [SerializeField]
    private Text runScoreText = null;

    [SerializeField]
    private FloatVariable runScore = null;

    private void Update() {
        runScoreText.text = ((int)runScore.value).ToString("N0");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XXXGame.Gameplay;

public class CanvasLogicGameOver : CanvasLogic {

    [SerializeField] private Text scoreCountText;

    public override void OnEnter() {
        scoreCountText.text = GameManager.instance.GetScore().ToString("#,#");
    }

}

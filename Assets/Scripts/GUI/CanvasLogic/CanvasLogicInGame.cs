using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLogicInGame : CanvasLogic {

    static public CanvasLogicInGame instance;

    [SerializeField] private Text scoreCount;

    private void Awake() {
        instance = this;
    }

    public void SetScore(int score) {
        scoreCount.text = score.ToString();
    }

    //public override void OnEnter() {
    //    print("InGame >> OnEnter()");
    //}

    //public override void OnLeave() {
    //    print("InGame >> OnLeave()");
    //}
}

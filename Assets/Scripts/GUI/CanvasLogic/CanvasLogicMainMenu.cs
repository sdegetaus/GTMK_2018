using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XXXGame.Gameplay;
using XXXGame.GUI;

public class CanvasLogicMainMenu : CanvasLogic {



    // Read Space Input
    private void Update() {
        if (Input.GetKey("space")) {
            GameManager.instance.StartGame();
        }
    }
     
    public override void OnEnter() {
        AmbientManager.instance.UpdateShaderValues(true);
    }

    //public override void OnLeave() {

    //}

}

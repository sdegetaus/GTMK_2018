using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLogicMainMenu : CanvasLogic {

    public override void OnEnter() {
        AmbientManager.instance.isOn = true;
    }

    public override void OnLeave() {
        AmbientManager.instance.isOn = false;
    }

}

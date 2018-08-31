using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLogicMainMenu : CanvasLogic {

    // GUI ELEMENTS
    // [SerializeField] private Something smth; 

    public override void OnEnter() {
        print("MainMenu >> OnEnter()");
    }

    public override void OnLeave() {
        print("MainMenu >> OnLeave()");
    }

}

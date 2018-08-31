using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLogicInGame : CanvasLogic {

    // GUI ELEMENTS
    // [SerializeField] private Something smth; 

    public override void OnEnter() {
        print("InGame >> OnEnter()");
    }

    public override void OnLeave() {
        print("InGame >> OnLeave()");
    }

}

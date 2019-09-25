using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    // Private Variables
    private Player player = null;

    private void Start() {
        player = GetComponent<Player>();
    }

    private void Update() {

        if (!GameManager.IsRunPlaying) {

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
                Events.instance.OnRunStarted.Raise();
            }

            return;
        }

        if (Consts.debugPlayerMovement) {

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                player.MoveLeft();
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                player.MoveRight();
                return;
            }

        }

    }

}

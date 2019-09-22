using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour {

    private GameManager game;

    private void Start() {
        game = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other) {
        //game.lanesController.SpawnToBack();
    }
}
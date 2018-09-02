using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XXXGame.Gameplay;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider collision) {
        ElementSpawner.instance.continueSpawning = false;
        PlayerController.instance.ResetEvents();
        GameManager.instance.SetGameOver();
        //SceneManager.LoadScene((int)Scenes.Entry);
    }
}

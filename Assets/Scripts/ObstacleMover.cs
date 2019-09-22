using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

    private GameManager game;

    private void Awake() {
        game = GameManager.instance;
    }

    private void Update() {
       
        //transform.position = new Vector3(
        //    transform.position.x + game.obstacleSpeed.value * Time.deltaTime,
        //    transform.position.y, transform.position.z
        //);

        //if (transform.position.x <= game.test) {
        //    game.lanesController.SpawnToBack();
        //    return;
        //}
    }
}
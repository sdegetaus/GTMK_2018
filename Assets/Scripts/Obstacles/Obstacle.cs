using UnityEngine;

public class Obstacle : MonoBehaviour, ICollide {

    public void OnTriggerEnter(Collider other) {

        if (GameManager.instance.godMode) return;
        Events.instance.OnRunOver.Raise();

    }

}
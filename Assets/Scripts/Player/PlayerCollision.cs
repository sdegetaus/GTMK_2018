using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger");
        //Time.timeScale = 0;
    }

}

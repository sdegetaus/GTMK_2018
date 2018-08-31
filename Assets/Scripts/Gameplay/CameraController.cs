using UnityEngine;

namespace XXXGame.Gameplay {

    public class CameraController : MonoBehaviour {
        static public CameraController instance;
        public void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
        }
    }
}
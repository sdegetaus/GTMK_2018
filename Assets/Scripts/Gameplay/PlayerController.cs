using UnityEngine;

namespace XXXGame.Gameplay {

    public partial class PlayerController : MonoBehaviour {

        public static PlayerController instance;

        private void Awake() {
            instance = this;
        }

    }
}
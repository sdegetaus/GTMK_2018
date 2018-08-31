using UnityEngine;
using System.Collections;

namespace XXXGame.Gameplay {

    // PUBLIC ENUMS
    // ToDo

    /// <summary>
    /// GameManager: singleton that manages the game state; it coordinates with all of the other classes. 
    /// </summary>
    public class GameManager : MonoBehaviour {

        static public GameManager instance;

        public void Awake() {
            instance = this;
        }
        
    }
}
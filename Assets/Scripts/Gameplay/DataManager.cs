using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace XXXGame.Gameplay {

    // PUBLIC ENUMS
    // ToDo

    /// <summary>
    /// DataManager is a Singleton which manages data across the game.
    /// </summary>
    public class DataManager : MonoBehaviour {

        static public DataManager instance;

        public void Awake() {
            instance = this;
        }

        // ----- EXAMPLES -----

        //public void AddToScore(float/int) {
        //    [...]
        //}

        //public void SetScore(float/int) {
        //    [...]
        //}

        //public int GetScore() {
        //    [...]
        //}

        //public int GetPlayCount() {
        //    return PlayerPrefs.GetInt();
        //}
    }
}
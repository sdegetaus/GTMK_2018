using UnityEngine;

namespace XXXGame.Gameplay {

    /// <summary>
    /// StaticData: singleton class that holds all the data not directly game-related: e.g. power up lenght / cost.
    /// </summary>
    public class StaticData : MonoBehaviour {
        static public StaticData instance;
        public void Awake()
        {
            instance = this;
        }
    }
}
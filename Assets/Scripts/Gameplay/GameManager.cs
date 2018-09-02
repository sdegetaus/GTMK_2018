using UnityEngine;
using System.Collections;
using XXXGame.GUI;

namespace XXXGame.Gameplay {

    // PUBLIC ENUMS
    // ToDo

    /// <summary>
    /// GameManager: singleton that manages the game state; it coordinates with all of the other classes. 
    /// </summary>
    public class GameManager : MonoBehaviour {

        static public GameManager instance;
        static public bool isGamePaused = false;

        private int score;

        public void Awake() {
            instance = this;
        }

        private void Update() {
            CountScore();
        }

        public void StartGame() {
            score = 0;
            Ball.instance.StartThiShit();
            AmbientManager.instance.UpdateShaderValues(false);
            GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
            CanvasLogicInGame.instance.SetScore(0);
        }

        public void StopGame() {
            Ball.instance.StopEverythingDamnIt(); // Ball Mover Stop
            //ElementSpawner.instance.SpawnerStopper();
        }

        public void PauseGame() {
            Time.timeScale = 0.0f;
            isGamePaused = true;
        }

        public void ResumeGame() {
            Time.timeScale = 1.0f;
            isGamePaused = false;
        }

        public void SetGameOver() {
            StopGame();
            GUIStateMachine.instance.ChangeGUIState(GUIState.GameOver);
        }

        private void CountScore() {
            if (GUIStateMachine.instance.GetCurrentGUIState() == GUIState.InGame) {
                if (!isGamePaused) {
                    score += 1;
                    CanvasLogicInGame.instance.SetScore(score);
                }
            }
        }

        public int GetScore() {
            return score;
        }
    }
}
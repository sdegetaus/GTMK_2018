using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static public GameManager instance;
    static public bool isGamePaused = false;

    private int score;

    public void Awake() {
        //instance = this;
    }

    private void Update() {
        //CountScore();

        //if (Input.GetKey("escape")) {
        //    QuitGame();
        //}
    }

    public void StartGame() {
        //score = 0;
        //Ball.instance.StartThiShit();
        //ElementSpawner.instance.continueSpawning = true;
        //ElementSpawner.instance.SpawnObstacles();
        //AmbientManager.instance.UpdateShaderValues(false);
        //GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);
        //CanvasLogicInGame.instance.SetScore(0);
    }

    public void StopGame() {
        //Ball.instance.StopEverythingDamnIt(); // Ball Mover Stop
        //ElementSpawner.instance.SpawnerStopper();
    }

    public void PauseGame() {
        //Time.timeScale = 0.0f;
        //isGamePaused = true;
    }

    public void ResumeGame() {
        //Time.timeScale = 1.0f;
        //isGamePaused = false;
    }

    public void SetGameOver() {
        //StopGame();
        //GUIStateMachine.instance.ChangeGUIState(GUIState.GameOver);
    }

    private void CountScore() {
        //if (GUIStateMachine.instance.GetCurrentGUIState() == GUIState.InGame) {
        //    if (!isGamePaused) {
        //        score += 1;
        //        CanvasLogicInGame.instance.SetScore(score);
        //    }
        //}
    }

    public int GetScore() {
        return score;
    }

    public void Replay() {
        //ElementSpawner.instance.continueSpawning = true;
        //ElementSpawner.instance.SpawnObstacles();

        //AmbientManager.instance.UpdateShaderValues(false);

        //GUIStateMachine.instance.ChangeGUIState(GUIState.InGame);

        ////Ball.instance.ResetBallPos();

        //score = 0;
        //CanvasLogicInGame.instance.SetScore(0);

        //Ball.instance.StartThiShit();
    }

    public void QuitGame() {
        //Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialLoading : MonoBehaviour {

    private void Start() {
        StartCoroutine(
            LoadSceneCoroutine()
        );
    }

    private IEnumerator LoadSceneCoroutine() {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)Scene.Main, LoadSceneMode.Additive);

        // disable scene swapping while the asyncOperation is loading...
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone) {

            // TODO:
            //// pass on the progress value of the AsyncOperation to the progresBar UI Element
            ////if (showLoadingCanvas) {
            ////    progressBar.UpdateProgressBarValue(asyncOperation.progress);
            ////}

            // when the progress is above 0.9 (is done)
            // allow sceneActivation
            if (asyncOperation.progress >= 0.9f) {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

        // set active scene (where gameObjects will be instantiated) to the changed scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)Scene.Main));

        asyncOperation = SceneManager.UnloadSceneAsync((int)Scene.LoadingScreen);
        yield return asyncOperation;

    }
    
}
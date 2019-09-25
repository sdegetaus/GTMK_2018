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
        yield return SceneManager.LoadSceneAsync((int)Scene.Main);
    }

}
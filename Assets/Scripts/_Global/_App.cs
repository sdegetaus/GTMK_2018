using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class _App : MonoBehaviour {

    public static _App instance;

    void Awake() {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject); 
        }
        DontDestroyOnLoad(this);

        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Start() {}

    private void LoadPreferences() {}

    void OnApplicationPause(bool pauseStatus) {
        Debug.Log("OnApplicationPause");
    }
    void OnApplicationQuit() {
        Debug.Log("OnApplicationQuit");
        //PlayerPrefs.Save();
    }
}

using UnityEngine;

public class _Assets : MonoBehaviour {

    public static _Assets instance;

    public Material normalObstacleMat;
    public Material outlineMat;

    public void Awake() {
        instance = this;
    }


}

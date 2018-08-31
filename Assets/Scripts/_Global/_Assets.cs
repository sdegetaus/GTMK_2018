using UnityEngine;

public class _Assets : MonoBehaviour {

    public static _Assets instance;

    public void Awake() {
        instance = this;
    }
}

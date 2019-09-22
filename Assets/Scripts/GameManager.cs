using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Variables")]
    public FloatVariable obstacleSpeed;

    [Header("Class References")]
    public LanesController lanesController;
    public EndCollider endCollider;

    private void Awake() {
        instance = this;
    }

}
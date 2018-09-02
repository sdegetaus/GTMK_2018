using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AmbientManager : MonoBehaviour {

    static public AmbientManager instance;

    // Cacheing Shaders' ID
    static readonly int ambientEnable = Shader.PropertyToID("_LM");
    static readonly int ambientColor = Shader.PropertyToID("_LMColor");
    static readonly int ambientPower = Shader.PropertyToID("_LMPower");

    [HideInInspector] public bool isOn = false;
    [SerializeField] private float strenght;
    [SerializeField] private Color color;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        UpdatedShaderValues(isOn);
    }

    public void UpdatedShaderValues(bool isMenu) {
        if (isMenu) {
            Shader.SetGlobalFloat(ambientEnable, BoolToFloat(isOn));
            Shader.SetGlobalFloat(ambientPower, strenght);
            Shader.SetGlobalColor(ambientColor, color);
        } else {
            Shader.SetGlobalFloat(ambientEnable, BoolToFloat(isOn));
            Shader.SetGlobalFloat(ambientPower, 0.0f);
            Shader.SetGlobalColor(ambientColor, new Color(1,1,1));
        }
    }

    private float BoolToFloat(bool b) {
        if(isOn) {
            return 1.0f;
        } else {
            return 0.0f;
        }
    }
}


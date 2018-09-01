using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AmbientManager : MonoBehaviour
{
    // Cacheing Shaders' ID
    static readonly int ambientEnable = Shader.PropertyToID("_LM");
    static readonly int ambientColor = Shader.PropertyToID("_LMColor");
    static readonly int ambientPower = Shader.PropertyToID("_LMPower");

    [SerializeField] private bool isOn = false;
    [SerializeField] private float strenght;
    [SerializeField] private Color color;

    public void UpdatedShaderValues(bool isMenu)
    {
        if (isMenu) {
            isOn = true;
            Shader.SetGlobalFloat(ambientEnable, BoolToFloat(isOn));
            Shader.SetGlobalFloat(ambientPower, strenght);
            Shader.SetGlobalColor(ambientColor, color);
        } else {
            isOn = false;
            Shader.SetGlobalFloat(ambientEnable, BoolToFloat(isOn));
        }
    }

    private float BoolToFloat(bool b) {
        if(isOn) {
            return 1;
        } else {
            return 0;
        }
    }
}


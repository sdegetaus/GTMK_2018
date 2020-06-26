using UnityEngine;

[CreateAssetMenu(menuName = Consts.scriptableObjectBasePath + "Variables/Random Float")]
public class RandomFloatVariable : FloatVariable
{

    // Inspector Variables
    public float min;
    public float max;

    public override float value
    {
        get => Random.Range(min, max);
        set => _value = value;
    }
}
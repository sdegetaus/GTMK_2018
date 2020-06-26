using UnityEngine;

[CreateAssetMenu(menuName = Consts.scriptableObjectBasePath + "Variables/Float")]
public class FloatVariable : ScriptableObject
{

    [SerializeField]
    protected float _value;

    public virtual float value
    {
        get => _value;
        set => _value = value;
    }

}
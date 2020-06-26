using UnityEngine;

[CreateAssetMenu(menuName = Consts.PATH_ASSET_MENU + "Variables/Float")]
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
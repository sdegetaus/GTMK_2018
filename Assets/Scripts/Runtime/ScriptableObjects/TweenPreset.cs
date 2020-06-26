using UnityEngine;

[CreateAssetMenu(menuName = Consts.PATH_ASSET_MENU + "Tween Preset")]
public class TweenPreset : ScriptableObject
{
    public float time;
    public LeanTweenType tweenType;
}

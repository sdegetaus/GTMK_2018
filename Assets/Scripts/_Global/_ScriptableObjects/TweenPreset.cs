using UnityEngine;

[CreateAssetMenu(menuName = Consts.scriptableObjectBasePath + "Tween Preset")]
public class TweenPreset : ScriptableObject {

    public float time;
    public LeanTweenType tweenType;

}

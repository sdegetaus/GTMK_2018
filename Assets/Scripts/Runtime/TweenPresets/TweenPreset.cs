using UnityEngine;

namespace GMTK
{
    [CreateAssetMenu(menuName = Consts.PATH_ASSET_MENU + "Tween Preset")]
    public class TweenPreset : ScriptableObject
    {
        public float to;
        public float time;
        public LeanTweenType ease;
    }
}
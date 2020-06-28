using UnityEngine;

namespace GMTK
{
    public sealed class Assets : Singleton<Assets>
    {
        [Header("Variables")]
        public FloatVariable Score = null;
        public FloatVariable Speed = null;
        public FloatVariable LerpSpeed = null;
        public FloatVariable SpawnYieldTime = null;

        [Header("Signaling Arrows")]
        public Sprite arrowLeft = null;
        public Sprite arrowStraight = null;
        public Sprite arrowRight = null;

    }
}
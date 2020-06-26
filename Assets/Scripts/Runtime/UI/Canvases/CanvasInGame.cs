using UnityEngine;
using UnityEngine.UI;

namespace GMTK
{
    public class CanvasInGame : CanvasLogic
    {
        [SerializeField]
        private Text runScoreText = null;

        // Private Variables
        private FloatVariable score = null;

        private void Start()
        {
            score = Assets.Instance.Score;
        }

        private void Update() // move to coroutine
        {
            runScoreText.text = ((int)score.value).ToString("N0");
        }
    }
}
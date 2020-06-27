using UnityEngine;
using UnityEngine.UI;

namespace GMTK
{
    public class CanvasRunOver : CanvasLogic
    {
        [SerializeField]
        private Canvas deathCanvas = null;

        [SerializeField]
        private Canvas statsCanvas = null;

        [Space]

        [SerializeField]
        private Text runScoreText = null;

        private void Start()
        {
            if (!deathCanvas.gameObject.activeSelf)
                deathCanvas.gameObject.SetActive(true);

            if (!statsCanvas.gameObject.activeSelf)
                statsCanvas.gameObject.SetActive(true);
        }

        public override void OnEnter()
        {
            runScoreText.text = ((int)Assets.Instance.Score.value).ToString("N0");
            deathCanvas.enabled = true;
            statsCanvas.enabled = false;
            Debug.LogError($"{deathCanvas.enabled}, {statsCanvas.enabled}");
        }

        public void Switch()
        {
            deathCanvas.enabled = false;
            statsCanvas.enabled = true;
            CanvasPersistent.CinematicOut();
        }

    }
}
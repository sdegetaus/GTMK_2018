using UnityEngine;

public class UIHelperFPS : MonoBehaviour
{
    // Inspector Variables
    [SerializeField] private float updateInterval = 0.5f;
    [Range(0, 50)] [SerializeField] private int fontSize = 14;
    [SerializeField] private Color textColor = Color.white;

    // Private Variables
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval
    private string fps = "Loading...";

    private void Start()
    {
        timeleft = updateInterval;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        GUI.contentColor = textColor;
        GUI.Label(new Rect(2, 0, fontSize * 2, fontSize + 5), fps);
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        // interval ended
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            float f_fps = accum / frames;
            fps = System.String.Format("{0:F0}", f_fps);

            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
}
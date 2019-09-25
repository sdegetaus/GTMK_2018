using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GUIVersion : MonoBehaviour {
    public Text versionText = null;
    private void Start() => versionText.text = "v" + Application.version;
}
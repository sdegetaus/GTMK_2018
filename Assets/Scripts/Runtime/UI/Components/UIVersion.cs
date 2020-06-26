using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIVersion : MonoBehaviour
{
    public Text versionText = null;
    private void Start() => versionText.text = Version.Display;
}
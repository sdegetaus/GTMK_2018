using UnityEditor;
using UnityEngine;
using GMTK;

public static class EditorTools
{
    [MenuItem("Game/Toggle God Mode _g", false)]
    private  static void ToggleGodMode()
    {
        GameManager.GodMode = !GameManager.GodMode;
    }

    [MenuItem("Game/Toggle God Mode _g", true)]
    private static bool ValidateToggleGodMode() => Application.isPlaying;

}

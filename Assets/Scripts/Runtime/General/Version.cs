using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version : ScriptableSingleton<Version>
{
    public static string Display
    {
        get => $"{Application.version}";
    }
}

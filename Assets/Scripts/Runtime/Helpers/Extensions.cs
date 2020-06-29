using System.Runtime.CompilerServices;
using UnityEngine;

public static class Extensions
{
    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null) =>
        new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);

    public static bool HasChance(this float percent)
    {
        if (percent >= 100f) return true;
        if (percent <= 0f) return false;
        return UnityEngine.Random.value > (100f - percent) / 100f;
    }
    public static bool HasChance(this int percent) => HasChance(percent);
}

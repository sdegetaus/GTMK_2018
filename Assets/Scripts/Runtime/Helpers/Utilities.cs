using System;

public static class Utilities
{
    public static T GetRandomEnum<T>()
    {
        Array A = Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public static bool IsMobile()
    {
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8)
            return true;
#else
        return false;
#endif
    }
}
using System;

public static class Utilities
{
    public static T GetRandomEnum<T>()
    {
        Array A = Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {

    private static System.Random rand = new System.Random();

    public static T GetRandomEnum<T>() {
        Array A = Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    public static bool IsProbableBy(int probability) {
        float range = rand.Next(1, 101);
        if (range <= probability) return true;
        return false;
    }
}
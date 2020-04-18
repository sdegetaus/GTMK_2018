using UnityEngine;
using System.Linq;

public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject {

    static T _instance = null;

    public static T instance {
        get {
            if (_instance == null) {
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            }
            if (_instance == null) {
                _instance = CreateInstance<T>();
            }
            return _instance;
        }
    }

}
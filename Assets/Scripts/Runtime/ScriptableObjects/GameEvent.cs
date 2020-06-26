using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = Consts.PATH_ASSET_MENU + "Events/Event")]
public class GameEvent : ScriptableObject
{

    private readonly List<UnityAction> listeners = new List<UnityAction>();

    public void Raise()
    {

        if (listeners.Count == 0)
        {
            Debug.LogError(this.name + " does not contain any actions to be invoked!");
            return;
        }

#if UNITY_EDITOR
        if (Consts.LOG_EVENTS) Debug.Log(this.name + " raised");
#endif

        for (int i = listeners.Count - 1; i >= 0; i--)
        {
#if UNITY_EDITOR
            if (Consts.LOG_EVENTS) Debug.LogFormat("{0} listened at {1}.", this.name, listeners[i].Method.DeclaringType.ToString());
#endif
            listeners[i].Invoke();
        }

    }

    public void RegisterListener(UnityAction listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(UnityAction listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

    public void UnregisterAll()
    {
        if (listeners.Count == 0) return;
        listeners.Clear();
    }

    //private void OnDisable() {
    //    UnregisterAll();
    //}

}
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor {

    public override void OnInspectorGUI() {

        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        if (GUILayout.Button("Raise")) {
            GameEvent gameEvent = (GameEvent)target;
            gameEvent.Raise();
        }

    }

}

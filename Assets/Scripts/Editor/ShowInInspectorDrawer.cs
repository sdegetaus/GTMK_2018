using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ShowInInspectorAttribute))]
public class ShowInInspectorDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        Debug.LogError("Hey");
        return base.CreatePropertyGUI(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUILayout.Label(label);
        return;
       //ShowInInspectorAttribute range = attribute as ShowInInspectorAttribute;
       // Debug.Log(attribute);
       // Debug.Log(range);
       // Debug.Log(property.ToString());

       // if (property.propertyType == SerializedPropertyType.Float)
       //     EditorGUI.Slider(position, property, range.min, range.max, label);
       // else if (property.propertyType == SerializedPropertyType.Integer)
       //     EditorGUI.IntSlider(position, property, Convert.ToInt32(range.min), Convert.ToInt32(range.max), label);
       // else
       //     EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
    }
}
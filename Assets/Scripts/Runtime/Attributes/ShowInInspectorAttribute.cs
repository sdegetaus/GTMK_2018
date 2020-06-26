using UnityEngine;

public class ShowInInspectorAttribute : PropertyAttribute
{
    public float min;
    public float max;

    public ShowInInspectorAttribute(float min = 0, float max = 5)
    {
        this.min = min;
        this.max = max;
    }
}
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public abstract class CanvasLogic : MonoBehaviour
{

    [HideInInspector] public Canvas canvas;
    [HideInInspector] public CanvasGroup canvasGroup;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OnEnter() { }

    public virtual void OnLeave() { }
}
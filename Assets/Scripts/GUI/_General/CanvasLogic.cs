using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public abstract class CanvasLogic : MonoBehaviour {

    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake() {
        canvas = GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OnEnter() { }

    public virtual void OnLeave() { }
}
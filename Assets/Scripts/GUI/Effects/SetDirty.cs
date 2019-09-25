using UnityEngine;
using UnityEngine.UI;

public class SetDirty : MonoBehaviour {
    public Graphic m_graphic;

    void Reset() {
        m_graphic = GetComponent<Graphic>();
    }

    void Update() {
        m_graphic.SetVerticesDirty();
    }
}
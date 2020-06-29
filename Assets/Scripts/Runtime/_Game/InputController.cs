using UnityEngine;
using UnityEngine.EventSystems;

namespace GMTK
{
    public class InputController : MonoBehaviour
    {
        // Cached Variables
        private new Camera camera = null;
        private Ray ray = default;
        private RaycastHit hit = default;

        private ISelectable selectable = null;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (EventSystem.current.IsPointerOverGameObject()) return;
#else
            if (EventSystem.current.IsPointerOverGameObject(0)) return;
#endif

            if (Input.GetMouseButtonDown(0))
            {
                selectable?.Deselect();
                ray = camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                if (hit.transform == null) return;
                selectable = hit.transform.GetComponent<ISelectable>();
                if (selectable is null) return;
                selectable.OnClick();
            }

            //if (Input.GetMouseButton(0))
            //{
            //    if (selectable is null) return;
            //    selectable.OnDrag(-camera.ScreenToWorldPoint(Input.mousePosition).x);
            //}

            //if (Input.GetMouseButtonUp(0))
            //{
            //    if (selectable is null) return;
            //    selectable.Deselect();
            //}

        }

    }
}
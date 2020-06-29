using UnityEditorInternal;
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
        private LaneEnum laneEnum = null;

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
                ray = camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                
                if (hit.transform is null) return;

                if (hit.transform.TryGetComponent<ISelectable>(out var _selectable))
                {
                    if (selectable != null && selectable == _selectable)
                    {
                        selectable.Deselect();
                        selectable = null;
                        return;
                    }
                    selectable?.Deselect();
                    selectable = _selectable;
                    selectable.OnClick();
                }
                else if (selectable != null && hit.transform.TryGetComponent(out laneEnum))
                {
                    selectable.MoveTo(laneEnum.value, () =>
                    {
                        selectable.Deselect();
                        selectable = null;
                        laneEnum = null;
                    });
                }
                
            }
        }
    }
}
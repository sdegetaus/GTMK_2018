using UnityEngine;

namespace GMTK
{
    public interface ICollide
    {
        void OnTriggerEnter(Collider other);
    }

    public interface ISelectable
    {
        void SetLane(Lane lane);
        void MoveTo(Lane lane, System.Action onComplete);
        void OnClick();
        void Select();
        void Deselect();
    }
}

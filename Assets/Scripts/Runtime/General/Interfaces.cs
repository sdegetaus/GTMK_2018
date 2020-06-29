using UnityEngine;

namespace GMTK
{
    public interface ICollide
    {
        void OnTriggerEnter(Collider other);
    }

    public interface ISelectable
    {
        void OnClick();
        void Select();
        void Deselect();
    }
}

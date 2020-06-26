using UnityEngine;

namespace GMTK
{
    public interface ICollide
    {
        void OnTriggerEnter(Collider other);
    }

    public interface ISelectable
    {
        void Select();
    }
}

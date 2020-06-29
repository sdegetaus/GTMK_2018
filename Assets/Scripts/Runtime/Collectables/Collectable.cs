using UnityEngine;

namespace GMTK
{
    public class Collectable : MonoBehaviour, ICollide, ISelectable
    {
        public CollectableEnum collectibleEnum = CollectableEnum.CollectibleTest0;

        public void OnTriggerEnter(Collider collider)
        {
            CollectableGroup collectibleGroup = gameObject.transform.parent.GetComponent<CollectableGroup>();
            collectibleGroup.DeactivateItem(collectibleEnum);
            GameManager.Instance.CollectableCollected(collectibleEnum);
        }

        public void Deselect()
        {
            Debug.LogError("Not implemented");
        }

        public void MoveTo(Lane lane)
        {
            Debug.LogError("Not implemented");
        }

        public void OnClick()
        {
            Debug.LogError("Not implemented");
        }

        public void Select()
        {
            Debug.LogError("Not implemented");
        }

        public void SetLane(Lane lane)
        {
            Debug.LogError("Not implemented");
        }

        public void MoveTo(Lane lane, System.Action onComplete)
        {
            Debug.LogError("Not implemented");
        }
    }
}
using UnityEngine;

namespace GMTK
{
    public class Collectable : MonoBehaviour, ICollide
    {

        public CollectableEnum collectibleEnum = CollectableEnum.CollectibleTest0;

        public void OnTriggerEnter(Collider collider)
        {

            CollectableGroup collectibleGroup = gameObject.transform.parent.GetComponent<CollectableGroup>();
            collectibleGroup.DeactivateItem(collectibleEnum);

            GameManager.Instance.CollectableCollected(collectibleEnum);
        }
    }
}
using UnityEngine;

namespace GMTK
{
    public class Collectable : MonoBehaviour, ICollide
    {

        public CollectableEnum collectibleEnum = CollectableEnum.CollectibleTest0;

        public void OnTriggerEnter(Collider collider)
        {

            CollectableGroup collectibleGroup = gameObject.transform.parent.GetComponent<CollectableGroup>();
            collectibleGroup.UnsetActiveItem(collectibleEnum);

            GameManager.Instance.CollectibleCollected(collectibleEnum);
        }
    }
}
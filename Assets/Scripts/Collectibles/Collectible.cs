using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, ICollide {

    public CollectibleEnum collectibleEnum = CollectibleEnum.CollectibleTest0;

    public void OnTriggerEnter(Collider collider) {

        CollectibleGroup collectibleGroup = gameObject.transform.parent.GetComponent<CollectibleGroup>();
        collectibleGroup.UnsetActiveItem(collectibleEnum);

        GameManager.instance.CollectibleCollected(collectibleEnum);
    }

}
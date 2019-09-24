using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, ICollide {

    private CollectibleEnum collectibleEnum = CollectibleEnum.CollectibleTest0;

    public void OnTriggerEnter(Collider collider) {
        GameManager.instance.CollectibleCollected(collectibleEnum);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGroup : SpawnGroup<Collectible, CollectibleEnum> {

    public override void OnCollision() {
        throw new System.NotImplementedException();
    }

}
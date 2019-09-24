using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsManager : MonoBehaviour {

    // Private Variables
    private GameManager gameManager = null;
    private Pooler pooler = null;

    private void Start() {
        gameManager = GameManager.instance;
    }

    public void ArrowsSpawning(Pooler pooler) {

        this.pooler = pooler;

        List<Arrows> arrows = new List<Arrows>(pooler.arrowsPool.count);

        for (int i = 0; i < pooler.arrowsPool.count; i++) {
            pooler.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: Consts.arrowsSeparation * i)
            );
        }
    }
}
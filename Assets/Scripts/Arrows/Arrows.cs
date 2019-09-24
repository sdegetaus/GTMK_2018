using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour {

    [SerializeField]
    private FloatVariable globalSpeed = null;

    private Pooler pooler;

    private void Start() {
        pooler = GameManager.instance.pooler;
    }

    private void Update() {

        transform.position = transform.position.With(
            x: transform.position.x + globalSpeed.value * Time.deltaTime
        );

        if (transform.position.x < -60.0f) {
            pooler.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: Consts.arrowsSeparation)
            );
            pooler.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: 0f)
            );
            pooler.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: -Consts.arrowsSeparation)
            );
        }
    }

}

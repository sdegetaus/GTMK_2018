using System;
using System.Collections;
using UnityEngine;

public class Arrows : MonoBehaviour {

    [SerializeField]
    private FloatVariable globalSpeed = null;

    // Private Variables
    private Pools pools;
    private Coroutine arrowsMovementCoroutine = null;

    private void Start() {

        Events.instance.OnRunOver.RegisterListener(OnRunOver);

        pools = GameManager.instance.pools;
        arrowsMovementCoroutine = StartCoroutine(ArrowsMovementCoroutine());
    }

    #region Event Handlers

    private void OnRunStarted() {
        arrowsMovementCoroutine = StartCoroutine(ArrowsMovementCoroutine());
    }

    private void OnRunOver() {
        if (arrowsMovementCoroutine != null) {
            StopCoroutine(arrowsMovementCoroutine);
            arrowsMovementCoroutine = null;
        }
        Events.instance.OnRunStarted.RegisterListener(OnRunStarted);
    }

    #endregion

    private IEnumerator ArrowsMovementCoroutine() {

        while (true) {

            transform.position = transform.position.With(
                x: transform.position.x + globalSpeed.value * Time.deltaTime
            );

            if (transform.position.x < -60.0f) {
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: Consts.arrowsSeparation)
                );
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: 0f)
                );
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: -Consts.arrowsSeparation)
                );
            }

            yield return null;
        }
    }
}

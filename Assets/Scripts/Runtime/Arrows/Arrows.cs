using System.Collections;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField]
    private FloatVariable globalSpeed = null;
    [SerializeField]
    private FloatVariable lerpSpeed = null;

    // Private Variables
    private Pools pools;
    private Coroutine arrowsMovementCoroutine = null;

    private void Start()
    {
        GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
        pools = GameManager.Pools;
        arrowsMovementCoroutine = StartCoroutine(ArrowsMovementCoroutine());
    }

    #region Event Handlers

    private void OnRunStarted()
    {
        if (arrowsMovementCoroutine == null)
            arrowsMovementCoroutine = StartCoroutine(ArrowsMovementCoroutine());
    }

    private void OnRunOver()
    {
        if (arrowsMovementCoroutine != null)
        {
            StopCoroutine(arrowsMovementCoroutine);
            arrowsMovementCoroutine = null;
        }
        GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
    }

    #endregion

    private IEnumerator ArrowsMovementCoroutine()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                transform.position.With(x: transform.position.x - globalSpeed.value),
                Time.fixedDeltaTime * lerpSpeed.value);

            if (transform.position.x < -60.0f)
            {
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: Consts.ARROWS_SEPARATION)
                );
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: 0f)
                );
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: -Consts.ARROWS_SEPARATION)
                );
            }

            yield return new WaitForFixedUpdate();
        }
    }
}

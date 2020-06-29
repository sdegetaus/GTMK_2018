using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public class Spawner : MonoBehaviour
    {
        // Private Variables
        private Pools pools = null;

        private Coroutine spawningCoroutine = null;

        private void Start()
        {
            pools = GameManager.Pools;

            GameManager.Events.OnPoolLoaded.RegisterListener(OnPoolLoaded);
            GameManager.Events.OnRunStarted.RegisterListener(OnRunStarted);
            GameManager.Events.OnRunOver.RegisterListener(OnRunOver);
        }

        #region Event Handlers

        private void OnPoolLoaded()
        {
            for (int i = 0; i < pools.arrowsPool.count; i++)
            {
                pools.Spawn(
                    PoolTag.Arrows,
                    Vector3.zero.With(x: Consts.ARROWS_SEPARATION * i)
                );
            }
        }

        private void OnRunStarted()
        {
            pools.DeactivateObjects();
            BeginSpawning();
        }

        private void OnRunOver()
        {
            if (spawningCoroutine != null)
            {
                StopCoroutine(spawningCoroutine);
                spawningCoroutine = null;
            }
        }

        #endregion

        public void BeginSpawning(bool fromResume = false)
        {
            if (spawningCoroutine is null)
            {
                spawningCoroutine = StartCoroutine(
                    EndlessSpawningRoutine(fromResume)
                );
            }
        }

        public void StopSpawning()
        {
            if (spawningCoroutine != null)
            {
                StopCoroutine(spawningCoroutine);
                spawningCoroutine = null;
            }
        }

        private IEnumerator EndlessSpawningRoutine(bool fromResume = false)
        {
            while (true)
            {
                if (fromResume)
                {
                    yield return new WaitForSeconds(
                        Assets.Instance.SpawnYieldTime.value
                    );
                }

                var newLane = GetRandomLane();

                // Collectable Spawning...
                if (5.0f.HasChance())
                {
                    var collectableGroup = pools.Spawn(
                        PoolTag.CollectableGroup,
                        Vector3.zero.With(x: Consts.SPAWN_POINT_X)
                    ).GetComponent<CollectableGroup>();

                    collectableGroup.Initialize(newLane);

                    yield return new WaitForSeconds(
                        Assets.Instance.SpawnYieldTime.value
                    );
                }

                // Obstacle Spawning...
                var obstacleGroup = pools.Spawn(
                    PoolTag.ObstacleGroup,
                    Vector3.zero.With(x: Consts.SPAWN_POINT_X)
                ).GetComponent<ObstacleGroup>();

                obstacleGroup.Initialize(newLane);

                yield return new WaitForSeconds(
                    Assets.Instance.SpawnYieldTime.value
                );
            }
        }

        private Lane GetRandomLane()
        {
            if (33.0f.HasChance())
                return Lane.Left;
            else if (33.0f.HasChance())
                return Lane.Right;
            else
                return Lane.Middle;
        }
    }
}
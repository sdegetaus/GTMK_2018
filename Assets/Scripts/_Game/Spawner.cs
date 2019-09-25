﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Private Variables
    private GameManager gameManager = null;
    private Pools pools = null;

    private Coroutine spawningCoroutine = null;

    [Space]

    #region PERCENTAGE TEST VARIABLES

    public float count_0;
    public float count_left;
    public float count_right;

    [Space]

    public float perc_0;
    public float perc_left;
    public float perc_right;

    [Space]

    public float perc_collectible;
    public float count_collectible;

    [Space]

    public float totalCount = 0;

    #endregion

    private void Start() {
        gameManager = GameManager.instance;
        pools = gameManager.pools;

        Events.instance.OnPoolLoaded.RegisterListener(OnPoolLoaded); 
        Events.instance.OnRunStarted.RegisterListener(OnRunStarted);
        Events.instance.OnRunOver.RegisterListener(OnRunOver);
    }


    #region Event Handlers

    private void OnPoolLoaded() {
        for (int i = 0; i < pools.arrowsPool.count; i++) {
            pools.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: Consts.arrowsSeparation * i)
            );
        }
    }

    private void OnRunStarted() {
        StartSpawning();
    }

    private void OnRunOver() {
        if (spawningCoroutine != null) {
            StopCoroutine(spawningCoroutine);
        }
    }

    #endregion

    public void StartSpawning() {
        if (spawningCoroutine == null) {
            spawningCoroutine = StartCoroutine(EndlessSpawning());
        }
    }

private IEnumerator EndlessSpawning() {

        while (true) {

            // Collectible Spawning...
            if (Helper.IsProbableBy(5)) {
                count_collectible++;
                CollectibleGroup collectibleGroup = pools.Spawn(
                    PoolTag.CollectibleGroup,
                    Vector3.zero.With(
                        x: Consts.globalSpawnPoint,
                        z: GetNewLanePosition() ?? 0
                    )
                ).GetComponent<CollectibleGroup>();

                collectibleGroup.Init();

                yield return new WaitForSeconds(
                    gameManager.obstacleSpawnYieldTime.value
                );
            }

            // Obstacle Spawning...
            ObstacleGroup obstacleGroup = pools.Spawn(
                PoolTag.ObstacleGroup,
                Vector3.zero.With(
                    x: Consts.globalSpawnPoint,
                    z: GetNewLanePosition() ?? 0
                )
            ).GetComponent<ObstacleGroup>();

            obstacleGroup.Init();

            yield return new WaitForSeconds(
                gameManager.obstacleSpawnYieldTime.value
            );
        }
    }

    // TEMP, TODO:
    private float? GetNewLanePosition() {

        float? newLanePosition = null;

        if (Helper.IsProbableBy(33)) {
            newLanePosition = -Consts.laneSeparation;
            count_left++;
        } else if (Helper.IsProbableBy(33)) {
            newLanePosition = Consts.laneSeparation;
            count_right++;
        } else {
            newLanePosition = 0;
            count_0++;
        }

        perc_0 = (count_0 * 100) / totalCount;
        perc_left = (count_left * 100) / totalCount;
        perc_right = (count_right * 100) / totalCount;
        perc_collectible = (count_collectible * 100) / totalCount;

        totalCount++;

        return newLanePosition;
    }
}
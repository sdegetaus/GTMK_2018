using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // Private Variables
    private GameManager gameManager = null;
    private Pooler pooler = null;

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
    }

    public void BeginSpawning(Pooler pooler) {

        this.pooler = pooler;

        // initialize arrows
        List<Arrows> arrows = new List<Arrows>(pooler.arrowsPool.count);
        for (int i = 0; i < pooler.arrowsPool.count; i++) {
            pooler.Spawn(
                PoolTag.Arrows,
                Vector3.zero.With(x: Consts.arrowsSeparation * i)
            );
        }

        spawningCoroutine = StartCoroutine(SpawningCoroutine());
    }

    public void StopSpawning() {
        StopCoroutine(spawningCoroutine);
    }

    private IEnumerator SpawningCoroutine() {

        while (true) {
            //Debug.Log("This shit is running...");
            // Collectible Spawning...
            if (Helper.IsProbableBy(5)) {
                count_collectible++;
                CollectibleGroup collectibleGroup = pooler.Spawn(
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
            ObstacleGroup obstacleGroup = pooler.Spawn(
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

        float? lanePosition = null;

        if (Helper.IsProbableBy(33)) {
            lanePosition = -Consts.laneSeparation;
            count_left++;
        } else if (Helper.IsProbableBy(33)) {
            lanePosition = Consts.laneSeparation;
            count_right++;
        } else {
            lanePosition = 0;
            count_0++;
        }

        perc_0 = (count_0 * 100) / totalCount;
        perc_left = (count_left * 100) / totalCount;
        perc_right = (count_right * 100) / totalCount;
        perc_collectible = (count_collectible * 100) / totalCount;

        totalCount++;

        return lanePosition;
    }
}
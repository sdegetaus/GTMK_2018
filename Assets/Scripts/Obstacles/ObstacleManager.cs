using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    // Private Variables
    private GameManager gameManager = null;
    private Pooler pooler = null;

    [Space]

    // TESTS

    public float count_0;
    public float count_left;
    public float count_right;

    [Space]

    public float perc_0;
    public float perc_left;
    public float perc_right;

    [Space]

    public float totalCount = 0;

    private void Start() {
        gameManager = GameManager.instance;
    }

    public void ObstacleSpawning(Pooler pooler) {
        this.pooler = pooler;
        StartCoroutine(ObstacleSpawningCoroutine());
    }

    private IEnumerator ObstacleSpawningCoroutine() {

        while (true) {

            float lanePosition = 0;

            if (Helper.IsProbableBy(33)) {
                lanePosition = -Consts.laneSeparation;
                count_left++;
            } else if (!Helper.IsProbableBy(33)) {
                lanePosition = Consts.laneSeparation;
                count_right++;
            } else {
                count_0++;
            }

            perc_0 = (count_0 * 100) / totalCount;
            perc_left = (count_left * 100) / totalCount;
            perc_right = (count_right * 100) / totalCount;

            totalCount++;

            ObstacleGroup obstacleGroup = pooler.Spawn(
                PoolTag.ObstacleGroup,
                Vector3.zero.With(
                    x: Consts.obstacleSpawnPoint,
                    z: lanePosition
                )
            ).GetComponent<ObstacleGroup>();

            obstacleGroup.Init();

            yield return new WaitForSeconds(
                gameManager.obstacleSpawnYieldTime.value
            );
        }
    }
}
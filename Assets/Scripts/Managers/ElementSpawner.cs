using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {

    [SerializeField] float[] seconds;
    [SerializeField] private float waitForSpawnerAtStartGame;

    public static ElementSpawner instance;
    public bool continueSpawning;
    private ObjectPooler objPoolerInst;


    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
 
    private void Start () {
        objPoolerInst = ObjectPooler.instance;
        continueSpawning = false;
        for (int i = 0; i <= 2; i++) {
            InstantiateEnviroment();
        }
	}
	
    // Initial Environment
	public void InstantiateEnviroment() { 
        if (objPoolerInst != null) {
            objPoolerInst.SpawnFromPool(PoolTypes.Enviroment.ToString(), Vector3.zero, Quaternion.identity);
            if (!continueSpawning) {
                StartCoroutine(SpawnObjects());
            }
            continueSpawning = true; // <-- ESTO!!
        }
    }

    public void InstantiateObstacles() {
        int r = Random.Range((int)PoolTypes.SmallWall, (int)PoolTypes.ThornObtacle + 1);
        if (objPoolerInst != null) {
            switch (r) {
                case (int)PoolTypes.SmallWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.SmallWall.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.MediumWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.MediumWall.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.LargeWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.LargeWall.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.Spring:
                    objPoolerInst.SpawnFromPool(PoolTypes.Spring.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.ThornObtacle:
                    objPoolerInst.SpawnFromPool(PoolTypes.ThornObtacle.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
                    break;
            }
        }
    }

    public void InstantiateSpring() {
        objPoolerInst.SpawnFromPool(PoolTypes.Spring.ToString(), new Vector3(_Cn.ObstacleStartingPos, 0, 0), Quaternion.identity);
    }

    private IEnumerator SpawnObjects() {
        yield return new WaitForSeconds(waitForSpawnerAtStartGame);
        while (continueSpawning) {
            InstantiateObstacles();
            yield return new WaitForSeconds(seconds[(int)Random.Range(0,seconds.Length)]);
        }
    }

    //private IEnumerator 

    //// Global Accessor
    //public void SpawnerStopper() {
    //    StopCoroutine(SpawnObjects());
    //}

}

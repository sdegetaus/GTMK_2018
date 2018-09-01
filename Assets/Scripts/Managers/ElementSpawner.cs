using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {
    public static ElementSpawner instance;
    public bool continueSpawning;
    [SerializeField] float seconds;
    ObjectPooler objPoolerInst;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        continueSpawning = true;
    }
    // Use this for initialization
    void Start () {
        objPoolerInst = ObjectPooler.instance;
        for (int i = 0; i <= 2; i++)
        {
            InstantiateEnviroment();
        }
	}
	
	public void InstantiateEnviroment()
    {
        if(objPoolerInst != null)
        {
            objPoolerInst.SpawnFromPool(PoolTypes.Enviroment.ToString(), Vector3.zero, Quaternion.identity);
            StartCoroutine(SpawnObjects(seconds));
        }
            
    }

    public void InstantiateObstacles()
    {
        int r = Random.Range((int)PoolTypes.SmallWall, (int)PoolTypes.ThornObtacle + 1);
        if (objPoolerInst != null)
            switch (r)
            {
                case (int)PoolTypes.SmallWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.SmallWall.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.MediumWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.MediumWall.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.LargeWall:
                    objPoolerInst.SpawnFromPool(PoolTypes.LargeWall.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.Spring:
                    objPoolerInst.SpawnFromPool(PoolTypes.Spring.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
                    break;
                case (int)PoolTypes.ThornObtacle:
                    objPoolerInst.SpawnFromPool(PoolTypes.ThornObtacle.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
                    break;
            }
            
    }
    public void InstantiateSpring()
    {
        objPoolerInst.SpawnFromPool(PoolTypes.Spring.ToString(), new Vector3(15, 0, 0), Quaternion.identity);
    }
    IEnumerator SpawnObjects(float SecondsBetweenSpawns)
    {
        yield return new WaitForSeconds(3f);
        while (continueSpawning)
        {
            InstantiateObstacles();
            yield return new WaitForSeconds(SecondsBetweenSpawns);
        }
    }
}

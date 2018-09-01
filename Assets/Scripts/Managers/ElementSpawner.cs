using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {
    public static ElementSpawner instance;
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
            objPoolerInst.SpawnFromPool(PoolTypes.Enviroment.ToString(), Vector3.zero, Quaternion.identity);
    }

    public void InstantiateObstacles()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{

    public GameObject objectPrefab;
    public int size;
    public bool shouldExpand = true;

    public PoolItem(GameObject obj, int amt, bool exp = true)
    {
        objectPrefab = obj;
        size = Mathf.Max(amt, 2); //*********************************************
        shouldExpand = exp;
    }
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<PoolItem> Pools;


    public List<List<GameObject>> pooledObjectsList;
    public List<GameObject> pooledObjects;
    private List<int> positions;

    void Awake()
    {

        SharedInstance = this;

        pooledObjectsList = new List<List<GameObject>>();
        pooledObjects = new List<GameObject>();
        positions = new List<int>();


        for (int i = 0; i < Pools.Count; i++)
        {
            ObjectPoolItemToPooledObject(i);
        }

    }


    public GameObject GetPooledObject(int index)
    {

        int curSize = pooledObjectsList[index].Count;
        for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
        {

            if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
            {
                positions[index] = i % curSize;
                return pooledObjectsList[index][i % curSize];
            }
        }

        if (Pools[index].shouldExpand)
        {

            GameObject obj = (GameObject)Instantiate(Pools[index].objectPrefab);
            obj.SetActive(false);
            obj.transform.parent = this.transform;
            pooledObjectsList[index].Add(obj);
            return obj;

        }
        return null;
    }

    public List<GameObject> GetAllPooledObjects(int index)
    {
        return pooledObjectsList[index];
    }


    public int AddObject(GameObject obj, int amt = 3, bool exp = true)
    {
        PoolItem item = new PoolItem(obj, amt, exp);
        int currLen = Pools.Count;
        Pools.Add(item);
        ObjectPoolItemToPooledObject(currLen);
        return currLen;
    }


    void ObjectPoolItemToPooledObject(int index)
    {
        PoolItem item = Pools[index];

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < item.size; i++)
        {
            GameObject obj = (GameObject)Instantiate(item.objectPrefab);
            obj.SetActive(false);
            obj.transform.parent = this.transform;
            pooledObjects.Add(obj);
        }
        pooledObjectsList.Add(pooledObjects);
        positions.Add(0);

    }
}

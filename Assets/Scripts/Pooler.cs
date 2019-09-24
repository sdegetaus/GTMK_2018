using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pooler : MonoBehaviour {

    [Serializable]
    public struct Pool {
        public PoolTag type;
        public int count;
        public GameObject prefab;
    }

    public Pool obstacleGroupPool;

    private List<Pool> pools = new List<Pool>();
    private Dictionary<PoolTag, Queue<GameObject>> poolGroup = new Dictionary<PoolTag, Queue<GameObject>>();

    private void Start() {
        pools.Clear();
        pools.Add(obstacleGroupPool);
    }

    public void InitializePool(UnityAction finishedCallback = null) =>
        StartCoroutine(
            InitializePoolCoroutine(finishedCallback)
        );

    private IEnumerator InitializePoolCoroutine(UnityAction onFinished = null) {

        // initialize obstacleGroupPool
        Queue<GameObject> poolObject = new Queue<GameObject>();
        for (int i = 0; i < obstacleGroupPool.count; i++) {
            GameObject obj = Instantiate(obstacleGroupPool.prefab, transform);
            obj.name += " " + i;
            obj.SetActive(false);
            poolObject.Enqueue(obj);
            yield return new WaitForEndOfFrame();
        }
        poolGroup.Add(obstacleGroupPool.type, poolObject);
        
        onFinished?.Invoke();
    }

    public GameObject Spawn(PoolTag tag, Vector3 position = default) {

        if (!poolGroup.ContainsKey(tag)) {
            Debug.LogError("PoolTag of type " + tag.ToString() + " doesn't exist!");
            return null;
        }

        GameObject objectToSpawn = poolGroup[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = Quaternion.identity;

        poolGroup[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
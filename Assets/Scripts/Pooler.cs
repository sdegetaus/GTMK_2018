using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pooler : MonoBehaviour {

    [Serializable]
    public class Pool {
        public PoolTag type;
        public int count;
        public GameObject prefab;
    }

    [SerializeField] private List<Pool> pools = new List<Pool>();
    private Dictionary<PoolTag, Queue<GameObject>> poolGroup = new Dictionary<PoolTag, Queue<GameObject>>();

    public void InitializePool(UnityAction finishedCallback = null) =>
        StartCoroutine(
            InitializePoolCoroutine(finishedCallback)
        );

    private IEnumerator InitializePoolCoroutine(UnityAction finishedCallback = null) {

        if (pools.Count == 0) yield break;

        foreach (Pool pool in pools) {
            Queue<GameObject> poolObject = new Queue<GameObject>();
            for (int i = 0; i < pool.count; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.name += " " + i;
                obj.SetActive(false);
                poolObject.Enqueue(obj);
            }
            poolGroup.Add(pool.type, poolObject);
            yield return new WaitForEndOfFrame();
        }
        finishedCallback?.Invoke();
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
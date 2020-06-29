using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public class Pools : MonoBehaviour
    {
        [Serializable]
        public struct Pool
        {
            public PoolTag type;
            public int count;
            public GameObject prefab;
        }

        public static bool IsReady = false;

        [Header("Pools")]
        public Pool obstacleGroupPool;
        public Pool collectibleGroupPool;
        public Pool arrowsPool;

        // Private Variables
        private Dictionary<PoolTag, Queue<GameObject>> poolGroup = new Dictionary<PoolTag, Queue<GameObject>>();

        public void Initialize()
        {
            StartCoroutine(
                InitializePoolCoroutine()
            );
        }

        public GameObject Spawn(PoolTag tag, Vector3 position = default)
        {
            if (!poolGroup.ContainsKey(tag))
            {
                Debug.LogError($"PoolTag of type {tag.ToString()} doesn't exist!");
                return null;
            }

            GameObject objectToSpawn = poolGroup[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = Quaternion.identity;

            poolGroup[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        private IEnumerator InitializePoolCoroutine()
        {
            var poolObjectsTransform = GameManager.Spawner.gameObject.transform;
            var poolObject = new Queue<GameObject>();

            for (int i = 0; i < obstacleGroupPool.count; i++)
            {
                var obj = Instantiate(obstacleGroupPool.prefab, poolObjectsTransform);
                obj.SetActive(false);
                poolObject.Enqueue(obj);
                yield return new WaitForEndOfFrame();
            }
            poolGroup.Add(obstacleGroupPool.type, poolObject);

            yield return null;

            // initialize collectiblePool
            poolObject = new Queue<GameObject>();

            for (int i = 0; i < collectibleGroupPool.count; i++)
            {
                var obj = Instantiate(collectibleGroupPool.prefab, poolObjectsTransform);
                obj.SetActive(false);
                poolObject.Enqueue(obj);
                yield return new WaitForEndOfFrame();
            }
            poolGroup.Add(collectibleGroupPool.type, poolObject);

            yield return null;

            // initialize arrowsPool
            poolObject = new Queue<GameObject>();

            for (int i = 0; i < arrowsPool.count; i++)
            {
                var obj = Instantiate(arrowsPool.prefab, poolObjectsTransform);
                obj.SetActive(false);
                poolObject.Enqueue(obj);
                yield return new WaitForEndOfFrame();
            }
            poolGroup.Add(arrowsPool.type, poolObject);

            yield return null;

            GameManager.Events.OnPoolLoaded.Raise();
            IsReady = true;
        }

        public void DeactivateObjects()
        {
            foreach (var obj in poolGroup[PoolTag.ObstacleGroup])
                obj.SetActive(false);

            foreach (var obj in poolGroup[PoolTag.CollectableGroup])
                obj.SetActive(false);
        }

    }
}
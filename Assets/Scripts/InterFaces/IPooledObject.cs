
using UnityEngine;

public interface IPooledObject{
    void OnObjectSpawn(Vector3 spawnTransform);
    void SetUpNumber(int number);
}

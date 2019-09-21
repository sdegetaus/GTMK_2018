using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour , IPooledObject {

    static public int spawnCount;

    [SerializeField] private Vector3 translation;
    [SerializeField] private float speed;
    
    public void OnObjectSpawn(Vector3 spawnTransform)
    {
        if(spawnCount <= 2) {
            this.transform.position = spawnTransform * (spawnCount % 3) - new Vector3(1.809f,0,0); //hardcoded 3 should be the size of the pool. // PACO por aquí está el pedo de la separación
        } else {
            this.transform.position = new Vector3(40f, 0, 0);
        }
        spawnCount++;
    }

    public void SetUpNumber(int number) {
        throw new System.NotImplementedException();
    }

    private void FixedUpdate() {
        if (transform.position.x <= -79f) {
            ElementSpawner.instance.InstantiateEnviroment();
        }
        transform.Translate(translation * ElementSpawner.instance.speedOfMovement * Time.deltaTime);
    }
}

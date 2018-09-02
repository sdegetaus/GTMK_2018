﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour , IPooledObject {
    static int spawnCount;

    [SerializeField] Vector3 translation;
    [SerializeField] float speed;
    
    public void OnObjectSpawn(Vector3 spawnTransform)
    {
        if(spawnCount <= 2)
        {
            this.transform.position = spawnTransform * (spawnCount % 3); //hardcoded 3 should be the size of the pool.
        }
        else
        {
            this.transform.position = new Vector3(39f, 0, 0);
        }
        spawnCount++;
    }

    public void SetUpNumber(int number)
    {
        throw new System.NotImplementedException();
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -79f)
        {
            ElementSpawner.instance.InstantiateEnviroment();
        }
        transform.Translate(translation * speed * Time.deltaTime);
        
    }
}

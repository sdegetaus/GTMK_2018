using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMoveTowardPlayer : MonoBehaviour {
    [SerializeField] Vector3 translation;
     [SerializeField] float speed;

    private void Start()
    {
        speed = 1;
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -79.5f)
        {
            ElementSpawner.instance.InstantiateEnviroment();
        }
        transform.Translate(translation * speed);

    }
}

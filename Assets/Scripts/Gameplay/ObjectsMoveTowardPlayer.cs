using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMoveTowardPlayer : MonoBehaviour {
    [SerializeField]private Vector3 translation;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(translation * ElementSpawner.instance.speedOfMovement * Time.deltaTime);
    }
}

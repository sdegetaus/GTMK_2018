using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XXXGame.Gameplay;

public class ObjectsMoveTowardPlayer : MonoBehaviour {
    [SerializeField]private Vector3 translation;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (transform.position.x < -5)
            PlayerController.instance.PlaceEventByForce();
        transform.Translate(translation * ElementSpawner.instance.speedOfMovement * Time.deltaTime);
    }
}

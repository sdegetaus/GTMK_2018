using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMoveTowardPlayer : MonoBehaviour {
    [SerializeField]private Vector3 translation;
     [SerializeField]private float speed;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(translation * speed * Time.deltaTime);
    }
}

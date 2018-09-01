using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour {
    [SerializeField] Vector3 translation;
    [SerializeField] float speed;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(translation * speed);
    }
}

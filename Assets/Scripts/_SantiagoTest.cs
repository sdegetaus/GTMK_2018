using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SantiagoTest : MonoBehaviour {

    private Renderer rend;

    private void Start()
    {
        rend = this.gameObject.GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        AddOutlineMaterial();
    }

    private void AddOutlineMaterial()
    {
        Material[] matArray = rend.materials;
        matArray[1] = _Assets.instance.outlineMat;
        rend.materials = matArray;
    }

}

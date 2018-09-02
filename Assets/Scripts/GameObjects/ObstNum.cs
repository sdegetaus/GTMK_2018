using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstNum : MonoBehaviour, IPooledObject {
    Image numberImage;
    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        numberImage = GetComponent<Image>();
	}

    public void OnObjectSpawn(Vector3 spawnTransform)
    {
        throw new System.NotImplementedException();
    }

    public void SetUpNumber(int number)
    {
        if (numberImage != null)
            numberImage.sprite = sprites[number];
    }
}

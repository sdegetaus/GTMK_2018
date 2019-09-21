using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstNum : MonoBehaviour{
     public Image numberImage;
    public Sprite[] sprites;
    [SerializeField]int number;
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

        this.number = number;
        if (numberImage != null)
            numberImage.sprite = sprites[number];
    }
}

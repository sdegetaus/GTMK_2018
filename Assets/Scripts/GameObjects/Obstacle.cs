using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XXXGame.Gameplay;


public enum ObstacleType
{
    SmallWall,
    MediumWall,
    LargeWall,
    ThornObstacle,
    Spring
}

public class Obstacle : MonoBehaviour, IPooledObject {
    
    [SerializeField] ObstacleType type;
    bool isJumpable;
    bool isMoveable;
    int number;
    [SerializeField] float upNumber;
    

    private void Start()
    {
        switch (type)
        {
            case ObstacleType.SmallWall:
                isJumpable = true;
                isMoveable = true;
                break;
            case ObstacleType.MediumWall:
                isJumpable = false;
                isMoveable = true;
                break;
            case ObstacleType.LargeWall:
                isJumpable = false;
                isMoveable = false;
                break;
            case ObstacleType.ThornObstacle:
                isJumpable = true;
                isMoveable = false;
                break;
        }

    }

    public void OnObjectSpawn(Vector3 spawnTransform)
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                if(!type.Equals(ObstacleType.ThornObstacle))
                    this.transform.position = spawnTransform + new Vector3(0, 0, 1.5f);
                break;
            case 1:
                if (type.Equals(ObstacleType.LargeWall))
                {
                    r = Random.Range(1, 3);
                    this.transform.position = spawnTransform + new Vector3(0, 0, 1.5f * Mathf.Pow(-1, r));
                }
                break;
            case 2:
                if (!type.Equals(ObstacleType.ThornObstacle))
                    this.transform.position = spawnTransform + new Vector3(0, 0, -1.5f);
                break;
        }

        switch (type)
        {
            case ObstacleType.ThornObstacle:
                ElementSpawner.instance.InstantiateSpring();
                break;
        }
    
    }

    public void SetUpNumber(int num)
    {
        PlayerController.selectionEvent += SelectObstacle;
        number = num;

    }

    public void DeleteNumber()
    {
        number = 0;
        PlayerController.selectionEvent -= SelectObstacle;
    }
    public void SelectObstacle(int num)
    {
        if(num == number)
        {
            PlayerController.translationEvent += Translate;
            transform.Translate(Vector3.up * upNumber);
        }
    }

    public void Translate(TranslationDir dir)
    {
        //Tenemos que definir los límites del movimiento
        switch (dir)
        {
            case TranslationDir.Up:
                if(transform.position.x < 5)
                {
                   transform.Translate(Vector3.right * Time.deltaTime * 10); // el 10 es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(5, upNumber, transform.position.z);
                }
                break;
            case TranslationDir.Down:
                if (transform.position.x > -5)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * 10); // el 10 es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(-5, upNumber, transform.position.z);
                }
                break;
            case TranslationDir.Left:
                if (transform.position.z < 1.5)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * 15); // el 10 es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, upNumber, 1.5f);
                }
                break;
            case TranslationDir.Right:
                if (transform.position.z > -1.5)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * 15); // el 10 es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, upNumber, -1.5f);
                }
                break;
        }
        //transform.Translate(translation * Time.deltaTime * 10); // el 10 es para que se mueva machin;
    }
}

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
    Material material;
    ObstNum obstacleNum;
    [SerializeField] GameObject obst;
    
    [SerializeField] float upNumber;

    [SerializeField] private Renderer[] rend;


    private void Start() {
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
                isMoveable = true;
                break;
            case ObstacleType.Spring:
                isJumpable = true;
                isMoveable = true;
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
        if (obst != null)
            obstacleNum = obst.GetComponent<ObstNum>();
        PlayerController.selectionEvent += SelectObstacle;
        number = num+1;
        if (obstacleNum != null)
        {
            obstacleNum.SetUpNumber(num);
        }
            

    }

    
    public void SelectObstacle(int num)
    {
        if(num == number)
        {
            if (isMoveable)
            {
                PlayerController.translationEvent += Translate;
                PlayerController.placeEvent += PlaceObject;
                PlayerController.placeEvent += RemoveOutlineMaterial;
                transform.Translate(Vector3.up * upNumber);
                AddOutlineMaterial();
            }
            else
            {
                PlayerController.selectionEvent -= SelectObstacle;
            }
        }
        if(num == 6 && type.Equals(ObstacleType.Spring))
        {
            PlayerController.translationEvent += Translate;
            PlayerController.placeEvent += PlaceObject;
            PlayerController.placeEvent += RemoveOutlineMaterial;
            transform.Translate(Vector3.up * upNumber);
            AddOutlineMaterial();
        }

    }

    public  void AddOutlineMaterial() {
        for (int i = 0; i < rend.Length; i++) {
            List<Material> matArray = new List<Material>();
            matArray.Add(_Assets.instance.outlineMat);
            matArray.Add(_Assets.instance.normalObstacleMat);
            rend[i].materials = matArray.ToArray();
        }
    }

    public void RemoveOutlineMaterial() {
        for (int i = 0; i < rend.Length; i++) {
            rend[i].material = _Assets.instance.normalObstacleMat;
        }
    }

    public void Translate(TranslationDir dir)
    {
        //Tenemos que definir los límites del movimiento
        
        switch (dir)
        {
            case TranslationDir.Up:
                Debug.Log("EstasMoviendo el objeto arriba");
                if (transform.position.x < 5)
                {
                    transform.Translate(Vector3.right); // el ElementSpawner.instance.speedOfMovement es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(5, upNumber, transform.position.z);
                }
                break;
            case TranslationDir.Down:
                Debug.Log("EstasMoviendo el objeto abajo");
                if (transform.position.x > -5)
                {
                    transform.Translate(Vector3.left); // el ElementSpawner.instance.speedOfMovement es para que se mueva machin;
                    Debug.Log("EstasMoviendo el objeto Izquierd");
                }
                else
                {
                    transform.position = new Vector3(-5, upNumber, transform.position.z);
                }
                break;
            case TranslationDir.Left:
                if (transform.position.z < 1.5)
                {
                    Debug.Log("EstasMoviendo el objeto derecha");
                    transform.Translate(Vector3.forward * 1.5f); // el ElementSpawner.instance.speedOfMovement es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, upNumber, 1.5f);
                }
                break;
            case TranslationDir.Right:
                if (transform.position.z > -1.5)
                {
                    transform.Translate(Vector3.back * 1.5f); // el ElementSpawner.instance.speedOfMovement es para que se mueva machin;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, upNumber, -1.5f);
                }
                break;
                
        }
        AudioManager.instance.Play("Movement");
        //transform.Translate(translation * Time.deltaTime * 10); // el 10 es para que se mueva machin;
    }
    public void PlaceObject()
    {
        Debug.Log("Object has been placed");
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        PlayerController.translationEvent -= Translate;
        PlayerController.placeEvent -= PlaceObject;
    }
}

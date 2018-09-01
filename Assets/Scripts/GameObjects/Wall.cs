using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wall : MonoBehaviour {
    public enum WallType
    {
        SmallWall,
        MediumWall,
        LargeWall
    }
    [SerializeField] WallType type;
    bool isJumpable;
    bool isMoveable;

    private void Start()
    {
        switch (type)
        {
            case WallType.SmallWall:
                isJumpable = true;
                isMoveable = true;
                break;
            case WallType.MediumWall:
                isJumpable = false;
                isMoveable = true;
                break;
            case WallType.LargeWall:
                isJumpable = false;
                isMoveable = false;
                break;
        }
    }
    
}

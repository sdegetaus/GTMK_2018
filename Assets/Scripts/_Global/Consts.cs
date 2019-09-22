using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PoolTag {
    LaneGroup,
    Arrows
}

public enum __PoolTypes {
    Enviroment,
    SmallWall,
    MediumWall,
    LargeWall,
    Spring,
    ThornObtacle
}

public class Consts {

    public const int totalLanes = 3;

    public const float lanesStartingPosition = -40.0f;
    public const float lanesSeparation = 40.0f;

    public const string scriptableObjectBasePath = "Custom/";

}
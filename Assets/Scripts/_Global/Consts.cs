using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PoolTag {
    LaneGroup,
    Arrows
}

public enum Lane {
    Left,
    Middle,
    Right
}

public class Consts {

    public const int totalLanes = 3;

    public const float laneGroupStartingPosition = -40.0f;
    public const float laneGroupSeparation = 40.0f;

    public const float laneSeparation = 1.6f;

    public const string scriptableObjectBasePath = "Custom/";

}
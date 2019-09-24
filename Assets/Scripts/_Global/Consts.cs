public enum PoolTag {
    Arrows,
    ObstacleGroup
}

public enum Lane {
    Left,
    Middle,
    Right
}

public enum ObstacleEnum {
    SingleNormal,
    DoubleNormal,
    SingleSpecial_0,
    DoubleSpecial_0,
    DoubleSpecial_1,
    DoubleSpecial_2
}

public static class Consts {

    public const int totalLanes = 3;

    public const float laneGroupStartingPosition = -40.0f;
    public const float laneGroupSeparation = 40.0f;

    public const float laneSeparation = 1.6f;

    public const float obstacleSpawnPoint = 30f;

    public const string scriptableObjectBasePath = "Custom/";

}
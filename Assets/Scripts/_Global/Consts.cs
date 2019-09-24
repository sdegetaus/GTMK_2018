
public enum PoolTag {
    ObstacleGroup,
    CollectibleGroup,
    Arrows,
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

public enum CollectibleEnum {
    CollectibleTest0,
    CollectibleTest1
}

public static class Consts {

    public const int totalLanes = 3;

    public const float arrowsSeparation = 30.0f;

    public const float laneSeparation = 1.6f;

    public const float globalSpawnPoint = 30f;

    public const string scriptableObjectBasePath = "Custom/";

}
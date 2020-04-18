
public static class Consts {

    #region Debug

    /// <summary>
    /// Master switch for debug variables
    /// </summary>
    public const bool debugOn = true;

    /// <summary>
    /// Useful to log GUIState changes.
    /// </summary>
    public const bool debugGUIChange = false;

    /// <summary>
    /// Whether to let the Player move by itself,
    /// or be able to control it yourself using WASD / Arrows
    /// </summary>
    public const bool debugPlayerMovement = debugOn;

    /// <summary>
    /// Option to log the events being invoked.
    /// </summary>
    public const bool debugLogEvents = false;

    #endregion

    #region Pool Positions

    /// <summary>
    /// Distance from center to center of the lanes.
    /// Left: -1.6; Middle: 0; Right: 1.6;
    /// </summary>
    public const float laneSeparation = 1.6f;

    /// <summary>
    /// Used by the Pooler and Spawner to
    /// know when to respawn the arrows (sense of movement).
    /// </summary>
    public const float arrowsSeparation = 30.0f;
    
    /// <summary>
    /// In what point of the X axis are the
    /// "spawnables" being spawned.
    /// </summary>
    public const float globalSpawnPoint = 30.0f;

    #endregion

    public const float initialObstacleSpawnYieldTime = 1.75f;
    public const float initialGlobalSpeed = 1f;

    #region Global Paths

    /// <summary>
    /// Base path for the ScriptableObjects AssetMenu path.
    /// </summary>
    public const string scriptableObjectBasePath = "Custom/";

    #endregion

}
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Static Variables
    public static bool IsRunPlaying = false;

    public bool godMode = false;

    [Header("Class References")]
    public Pools pools = null;
    public Spawner spawner = null;

    [SerializeField] private Player playerRef = null;

    // Private Variables
    private float m_globalSpeed = 0f;

    // Static References
    public static Player Player = null;
    public static Events Events = null;

    // Class References
    private Assets assets = null;

    private void Awake()
    {
        Events = GetComponentInChildren<Events>();
        Player = playerRef;
        assets = Assets.Instance;
    }

    private void Start()
    {
        Assets.Instance.Score.value = Consts.INITIAL_SPAWN_YIELD_TIME;
        Assets.Instance.Speed.value = Consts.INITIAL_SPEED;

        // register listeners
        Events.OnRunStarted.RegisterListener(OnRunStarted);
        Events.OnRunOver.RegisterListener(OnRunOver);
        Events.OnRunPaused.RegisterListener(OnRunPaused);
        Events.OnRunResumed.RegisterListener(OnRunResumed);

        // initialize pool (instantiate gameobjects)
        pools.InitializePool();
    }

    #region Event Handlers

    private void OnRunStarted()
    {
        UIManager.ChangeState(UIState.InGame);
        IsRunPlaying = true;
    }

    private void OnRunOver()
    {
        IsRunPlaying = false;
        UIManager.ChangeState(UIState.RunOver);
    }

    private void OnRunPaused()
    {
        if (!IsRunPlaying)
        {
            Debug.Log("Can't pause the game as it is already paused!");
            return;
        }

        UIManager.ChangeState(UIState.Pause, false);

        m_globalSpeed = assets.Speed.value;
        assets.Speed.value = 0;

        spawner.StopSpawning();
        IsRunPlaying = false;
    }

    private void OnRunResumed()
    {
        if (IsRunPlaying)
        {
            Debug.Log("Can't resume from pause as it the game is already running!");
            return;
        }

        UIManager.ChangeState(UIState.InGame, false);

        assets.Speed.value = m_globalSpeed;
        m_globalSpeed = 0;

        spawner.StartSpawning(true);
        IsRunPlaying = true;
    }

    #endregion

    // TODO:
    public void CollectibleCollected(CollectibleEnum collectibleEnum)
    {
        Debug.Log("Collectible Collected!");
    }

}
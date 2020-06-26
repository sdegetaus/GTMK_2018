using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Static Variables
    public static bool IsRunPlaying = false;

    public static bool GodMode = false;

    [Header("Class References")]

    [SerializeField] private Player playerRef = null;

    // Private Variables
    private float m_globalSpeed = 0f;

    // Static References
    public static Events Events = null;
    public static Pools Pools = null;
    public static Spawner Spawner = null;
    public static Player Player = null;

    // Class References
    private Assets assets = null;

    private void Awake()
    {
        assets = Assets.Instance;
        Events = GetComponentInChildren<Events>();
        Pools = GetComponentInChildren<Pools>();
        Spawner = GetComponentInChildren<Spawner>();
        InstantiatePlayer();
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
        Pools.InitializePool();
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

        Spawner.StopSpawning();
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

        Spawner.StartSpawning(true);
        IsRunPlaying = true;
    }

    #endregion

    private void InstantiatePlayer()
    {
        Player = Instantiate(playerRef);
        DontDestroyOnLoad(Player);
    }

    // TODO:
    public void CollectibleCollected(CollectibleEnum collectibleEnum)
    {
        Debug.Log("Collectible Collected!");
    }

}
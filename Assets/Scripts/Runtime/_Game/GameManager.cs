using UnityEngine;

namespace GMTK
{
    public class GameManager : Singleton<GameManager>
    {
        // Static Variables
        public static bool CanReadInput
        {
            get => Input.enabled;
            set => Input.enabled = value;
        }

        private static bool _GoldMove = false;
        public static bool GodMode
        {
            get => _GoldMove;
            set
            {
                Debug.Log($"God Mode {(value ? "Enabled" : "Disabled")}");
                _GoldMove = value;
            }
        }

        [Header("Class References")]

        [SerializeField] private Player playerRef = null;

        // Private Variables
        private float m_globalSpeed = 0f; // todo

        // Class References
        private Assets assets = null;

        // Static References
        public static InputController Input = null;
        public static Events Events = null;
        public static Pools Pools = null;
        public static Spawner Spawner = null;
        public static Player Player = null;

        private void Awake()
        {
            assets = Assets.Instance;
            assets.SpawnYieldTime.value = Consts.INITIAL_SPAWN_YIELD_TIME;
            assets.Speed.value = Consts.INITIAL_SPEED;

            Input = GetComponentInChildren<InputController>();
            Events = GetComponentInChildren<Events>();
            Pools = GetComponentInChildren<Pools>();
            Spawner = GetComponentInChildren<Spawner>();
            InstantiatePlayer();
        }

        private void Start()
        {
            // register listeners
            Events.OnRunStarted.RegisterListener(OnRunStarted);
            Events.OnRunOver.RegisterListener(OnRunOver);
            Events.OnRunPaused.RegisterListener(OnRunPaused);
            Events.OnRunResumed.RegisterListener(OnRunResumed);

            Pools.Initialize();
            CanReadInput = false;
        }

        #region Event Handlers

        private void OnRunStarted()
        {
            UIManager.ChangeState(UIState.InGame);
            CanReadInput = true;
        }

        private void OnRunOver()
        {
            CanReadInput = false;
            UIManager.ChangeState(UIState.RunOver);
        }

        private void OnRunPaused()
        {
            if (!CanReadInput)
            {
                Debug.Log("Can't pause the game as it is already paused!");
                return;
            }

            UIManager.ChangeState(UIState.Pause, false);

            m_globalSpeed = assets.Speed.value;
            assets.Speed.value = 0;

            Spawner.StopSpawning();
            CanReadInput = false;
        }

        private void OnRunResumed()
        {
            if (CanReadInput)
            {
                Debug.Log("Can't resume from pause as it the game is already running!");
                return;
            }

            UIManager.ChangeState(UIState.InGame, false);

            assets.Speed.value = m_globalSpeed;
            m_globalSpeed = 0;

            Spawner.BeginSpawning(true);
            CanReadInput = true;
        }

        #endregion

        private void InstantiatePlayer()
        {
            Player = Instantiate(playerRef);
            DontDestroyOnLoad(Player);
        }

        // TODO:
        public void CollectibleCollected(CollectableEnum collectibleEnum)
        {
            Debug.Log("Collectible Collected!");
        }
    }
}
using UnityEngine;

public class Events : Singleton<Events> {

    [Header("Pool Events")]
    public GameEvent OnPoolLoaded;

    [Header("Run Events")]
    public GameEvent OnRunStarted;
    public GameEvent OnRunOver;
    public GameEvent OnRunPaused;
    public GameEvent OnRunResumed;

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Private Variables
    private Player player = null;
    private Events events = null;

    private void Start()
    {
        events = GameManager.Events;
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!GameManager.IsRunPlaying)
        {
            // TODO: fix
            if (UIManager.CurrentState == UIState.MainMenu)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    events.OnRunStarted.Raise();
                    return;
                }
            }

            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                events.OnRunResumed.Raise();
                return;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            events.OnRunPaused.Raise();
            return;
        }

        if (Consts.DEBUG_PLAYER_MOV)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                player.MoveLeft();
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                player.MoveRight();
                return;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState<GameStateManager.CoreStates>
{
    public GameObject ShowUI;

    public PauseState(GameStateManager.CoreStates key) : base(key)
    {

    }

    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left pause state");
    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (cantransition)
        {
            cantransition = false;
            Time.timeScale = 1f;
            return GameStateManager.CoreStates.Gameplay;
        }

        return GameStateManager.CoreStates.Pause;


    }

    public override void UpdateState()
    {
    }
}
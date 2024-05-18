using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState<GameStateManager.CoreStates>
{
    public GameObject ShowUI;
    GameStateManager.CoreStates previousState;
    public bool paused = false;

    public PauseState(GameStateManager.CoreStates key) : base(key)
    {

    }

    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        paused = true;
        Time.timeScale = 0f;
        previousState = GameStateManager.instance.PreviousState;
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left pause state");
        Time.timeScale = 1f;
        paused = false;
    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (cantransition)
        {
            cantransition = false;
            return previousState;
        }

        return GameStateManager.CoreStates.Pause;
    }

    public override void UpdateState()
    {
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonState : BaseState<GameStateManager.CoreStates>
{

    private float timerValue = 0f;
    public GameWonState(GameStateManager.CoreStates key) : base(key)
    {}

    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left GameWon state");
    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (cantransition)
        {
            cantransition = false;
            return GameStateManager.CoreStates.Gameplay;
        }

        return GameStateManager.CoreStates.GameWon;
    }

    public override void UpdateState()
    {

    }
}
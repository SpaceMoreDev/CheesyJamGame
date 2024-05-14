using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState<GameStateManager.CoreStates>
{
    public List<GameObject> ShowUI = new List<GameObject>();
    public List<GameObject> HideUI = new List<GameObject>();

    public PauseState(GameStateManager.CoreStates key) : base(key)
    {

    }

    public override void EnterState()
    {
        //Debug.Log("Paused");

        foreach (GameObject go in ShowUI)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in HideUI)
        {
            go.SetActive(false);
        }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameStateManager : StateManager<GameStateManager.CoreStates>
{
    public enum CoreStates
    {
        Gameplay,
        Pause,
        Transition
    }

    [SerializeField] List<GameObject> GameplayUI = new List<GameObject>();
    [SerializeField] List<GameObject> PauseUI = new List<GameObject>();

    GameStateManager() {

        GameState gameState = new GameState(CoreStates.Gameplay);
        PauseState pauseState = new PauseState(CoreStates.Pause);
        gameState.ShowUI = GameplayUI;
        gameState.HideUI = PauseUI;

        pauseState.ShowUI = PauseUI;
        pauseState.HideUI = GameplayUI;

        States.Add(CoreStates.Gameplay, gameState);
        States.Add(CoreStates.Pause, pauseState);

    }

    private void Awake()
    {
        currentState = States[CoreStates.Pause];

    }
}

public class GameState : BaseState<GameStateManager.CoreStates>
{
    public List<GameObject> ShowUI = new List<GameObject>();
    public List<GameObject> HideUI = new List<GameObject>();


    public GameState(GameStateManager.CoreStates key) : base(key)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Gameplay");
        foreach (GameObject go in ShowUI)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in HideUI)
        {
            go.SetActive(false);
        }
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left gameplay state");
    }

    public override GameStateManager.CoreStates GetNextState()
    {
            return GameStateManager.CoreStates.Pause;
    }

    public override void UpdateState()
    {
    }
}

public class PauseState : BaseState<GameStateManager.CoreStates>
{
    public List<GameObject> ShowUI = new List<GameObject>();
    public List<GameObject> HideUI = new List<GameObject>();

    public PauseState(GameStateManager.CoreStates key) : base(key)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Paused");
        foreach (GameObject go in ShowUI)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in HideUI)
        {
            go.SetActive(false);
        }
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left pause state");
    }

    public override GameStateManager.CoreStates GetNextState()
    {
        return GameStateManager.CoreStates.Gameplay;
    }

    public override void UpdateState()
    {
        Debug.Log("paused!!");
    }
}
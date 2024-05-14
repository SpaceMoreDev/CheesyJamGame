using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameStateManager : StateManager<GameStateManager.CoreStates>
{
    public enum CoreStates
    {
        Gameplay,
        Pause,
        Transition
    }
    GameState gameState;
    PauseState pauseState;

    [SerializeField] List<GameObject> GameplayUI = new List<GameObject>();
    [SerializeField] List<GameObject> PauseUI = new List<GameObject>();

    [SerializeField] Text timer;

    bool ispaused = false;

    GameStateManager() {

        gameState = new GameState(CoreStates.Gameplay);
        pauseState = new PauseState(CoreStates.Pause);

        gameState.ShowUI = GameplayUI;
        gameState.HideUI = PauseUI;

        pauseState.ShowUI = PauseUI;
        pauseState.HideUI = GameplayUI;

        States.Add(CoreStates.Gameplay, gameState);
        States.Add(CoreStates.Pause, pauseState);

    }

    private void Awake()
    {
        gameState.timer = timer;
        currentState = States[CoreStates.Gameplay];
    }

    private void Start()
    {
        base.Start();
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState.cantransition = true;
            ispaused = !ispaused;
        }
    }
}




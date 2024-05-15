using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class GameStateManager : StateManager<GameStateManager.CoreStates>
{
    public enum CoreStates
    {
        Gameplay,
        Pause,
        GameOver
    }

    

    GameState gameState;
    PauseState pauseState;
    GameOverState gameoverState;

    [SerializeField] GameObject GameplayUI;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] Text Timer;
    [SerializeField] Text Collected;

    bool ispaused = false;

    GameStateManager() {

        gameState = new GameState(CoreStates.Gameplay);
        pauseState = new PauseState(CoreStates.Pause);
        gameoverState = new GameOverState(CoreStates.GameOver);

        States.Add(CoreStates.Gameplay, gameState);
        States.Add(CoreStates.Pause, pauseState);
        States.Add(CoreStates.GameOver, gameoverState);
        SwitchState += ShowUI;
    }

    private void OnDestroy()
    {
        SwitchState -= ShowUI;
    }

    private void ShowUI(CoreStates state)
    {
        PauseUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameplayUI.SetActive(false);

        switch (state)
        {
            case CoreStates.Gameplay:
                GameplayUI.SetActive(true);
                break;
            case CoreStates.Pause:
                PauseUI.SetActive(true);
                break;
            case CoreStates.GameOver:
                GameOverUI.SetActive(true);
                break;
        }
    }

    private void Awake()
    {
        gameState.timer = Timer;
        gameState.Collected = Collected;
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




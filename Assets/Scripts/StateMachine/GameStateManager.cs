using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Playables;
using UnityEditor;


public class GameStateManager : StateManager<GameStateManager.CoreStates>
{
    public enum CoreStates
    {
        Gameplay,
        Pause,
        Cutscene,
        GameOver
    }

    public static GameStateManager instance;

    GameState gameState;
    PauseState pauseState;
    GameOverState gameoverState;
    CutsceneState cutsceneState;
    
    [SerializeField] GameObject GameplayUI;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] Text Timer;
    [SerializeField] Text Collected;
    [SerializeField] PlayableDirector introCutscene;

    bool ispaused = false;

    GameStateManager() {

        gameState = new GameState(CoreStates.Gameplay);
        pauseState = new PauseState(CoreStates.Pause);
        gameoverState = new GameOverState(CoreStates.GameOver);
        cutsceneState = new CutsceneState(CoreStates.Cutscene);

        States.Add(CoreStates.Gameplay, gameState);
        States.Add(CoreStates.Pause, pauseState);
        States.Add(CoreStates.GameOver, gameoverState);
        States.Add(CoreStates.Cutscene, cutsceneState);
        SwitchState += ShowUI;
        instance = this;
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
            case CoreStates.Cutscene:
                break;
        }
    }

    private void Awake()
    {
        gameState.timer = Timer;
        gameState.Collected = Collected;

        if (introCutscene != null)
        {
            StartCutscene(introCutscene);
        }
        else
        {
            currentState = States[CoreStates.Gameplay];
        }
    }

    private void Start()
    {
        base.Start();
        PreviousState = currentState.StateKey;
        DontDestroyOnLoad(gameObject);

    }

    public static void StartCutscene(PlayableDirector director)
    {
        director.Play();
        instance.cutsceneState.director = director;
        if (currentState != null)
        {
            instance.TransitionToState(CoreStates.Cutscene);
        }
        else
        {
            currentState = instance.cutsceneState;
            instance.ShowUI(CoreStates.Cutscene);
        }

    }

    private void Update()
    {

        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;

            if (!ispaused)
            {
                instance.TransitionToState(CoreStates.Pause);
            }
            else
            {
                currentState.cantransition = true;
            }
        }
    }
}




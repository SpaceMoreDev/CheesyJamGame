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

public class GameState : BaseState<GameStateManager.CoreStates>
{
    public List<GameObject> ShowUI = new List<GameObject>();
    public List<GameObject> HideUI = new List<GameObject>();
    public Text timer;

    private float timerValue = 0f;
    public GameState(GameStateManager.CoreStates key) : base(key)
    {}

    public override void EnterState()
    {
        //Debug.Log("Gameplay");
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
        if (cantransition)
        {
            cantransition = false;
            return GameStateManager.CoreStates.Pause;
        }

        return GameStateManager.CoreStates.Gameplay;
    }

    public override void UpdateState()
    {
        if (timer != null)
        {
            float totalSeconds = Time.timeSinceLevelLoad;

            int seconds = Mathf.FloorToInt(totalSeconds);
            int minutes = Mathf.FloorToInt(totalSeconds / 60f);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            timer.text = formattedTime;
        }
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
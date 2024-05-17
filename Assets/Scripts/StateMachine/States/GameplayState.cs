using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : BaseState<GameStateManager.CoreStates>
{
    public GameObject ShowUI;
    public Text timer;
    public Text Collected;

    public bool isGameOver = false;
    public bool isGameWin = false;

    public int cheeseCount = 0;
    private int collected = 0;

    public static GameState instance;
    public static int collectedCheese { 
        set { 
            instance.collected = value;
            instance.ChangeText();

            if (value == CheeseInGame)
            {
                instance.isGameWin = true;
                Debug.Log("Won the game!!");
            }
        }
        get { 
            return instance.collected; 
        } 
    }

    public static int CheeseInGame
    {
        set
        {
            instance.cheeseCount = value;

            if (value == 0)
            {
                instance.isGameOver = true;
            }

            instance.ChangeText();
        }
        get
        {
            return instance.cheeseCount;
        }
    }

    private float timerValue = 0f;
    public GameState(GameStateManager.CoreStates key) : base(key)
    {
        instance = this;
    }

    public override void EnterState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ChangeText()
    {
        Collected.text = $"COLLECT THE CHEESE {collected}/{cheeseCount}";
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
        if (isGameOver)
        {
            return GameStateManager.CoreStates.GameOver;
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
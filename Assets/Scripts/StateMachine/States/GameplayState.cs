using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : BaseState<GameStateManager.CoreStates>
{
    public GameObject ShowUI;
    public Text timer;
    public Text Collected;
    public GameObject CullingCamera;

    public bool spawnCheeseMan 
    { set 
        {
            if (value)
            {
                SpawnManager.StartSpawn();
            }
            else
            {
                SpawnManager.StopSpawn();
            }
        
        } 
    }

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

            if (value == 0 || value == collectedCheese)
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
        elapsedTime = 0f;
    }

    public override void EnterState()
    {
        CullingCamera.SetActive(true);
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
        CullingCamera.SetActive(false);
    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (cantransition)
        {
            cantransition = false;
            return GameStateManager.CoreStates.Pause;
        }
        if(isGameWin)
        {
            return GameStateManager.CoreStates.GameWon;
        }
        if (isGameOver)
        {
            return GameStateManager.CoreStates.GameOver;
        }

        return GameStateManager.CoreStates.Gameplay;
    }
    private float elapsedTime=0f;
    public override void UpdateState()
    {
        if (timer != null)
        {
            elapsedTime += Time.deltaTime;  // Increment elapsed time by the time that has passed since the last frame

            int minutes = Mathf.FloorToInt(elapsedTime / 60F);  // Calculate the minutes
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);  // Calculate the seconds

            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
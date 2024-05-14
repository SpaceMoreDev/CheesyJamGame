using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : BaseState<GameStateManager.CoreStates>
{
    public List<GameObject> ShowUI = new List<GameObject>();
    public List<GameObject> HideUI = new List<GameObject>();
    public Text timer;

    public static int cheeseCount = 0;
    public static int collectedCheese = 0;

    private float timerValue = 0f;
    public GameState(GameStateManager.CoreStates key) : base(key)
    { }

    public override void EnterState()
    {
        Debug.Log($"cheese: {cheeseCount}");
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
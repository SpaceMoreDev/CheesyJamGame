using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneState : BaseState<GameStateManager.CoreStates>
{
    public static CutsceneState instance;
    public bool isFinished = false;
    public PlayableDirector director;

    public CutsceneState(GameStateManager.CoreStates key) : base(key)
    {
        instance = this;
    }
    public override void EnterState()
    {
        isFinished = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left Cutscene state");


    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (isFinished)
        {
            isFinished = false;
            return GameStateManager.CoreStates.Gameplay;
        }

        return GameStateManager.CoreStates.Cutscene;
    }

    public override void UpdateState()
    {

        if (director.state != PlayState.Playing && director.state != PlayState.Paused)
        {
            cantransition = true;
            isFinished = true;
        }
    }
}

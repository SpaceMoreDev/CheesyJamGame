using System.Collections;
using Unity.VisualScripting.FullSerializer;
//using UnityEditorInternal;
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
        director.stopped += OnTimelineEnd;

        isFinished = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void ExitState()
    {
        Debug.Log("-X- Left Cutscene state");
        director.stopped -= OnTimelineEnd;

    }

    public override GameStateManager.CoreStates GetNextState()
    {
        if (cantransition)
        {
            cantransition = false;
            return GameStateManager.CoreStates.Gameplay;
        }

        return GameStateManager.CoreStates.Cutscene;
    }

    void OnTimelineEnd(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            cantransition = true;
            isFinished = true;
        }
    }

    public override void UpdateState()
    {
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;


public class StateManager<EState> : MonoBehaviour where EState : Enum
{

    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    static public BaseState<EState> currentState;
    protected bool IsTransitioningState = false;

    public event Action<EState> SwitchState;
    public EState PreviousState;

    public void Start()
    {
        currentState.EnterState();
    }

    public void Update()
    {
        EState nextStateKey = currentState.GetNextState();

        if (!IsTransitioningState)
        {
            if (nextStateKey.Equals(currentState.StateKey))
            {
                currentState.UpdateState();
            }
            else
            {
                TransitionToState(nextStateKey);
            }
        }
    }

    public void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;

        PreviousState = currentState.StateKey;
        currentState.ExitState();
        currentState = States[stateKey];
        currentState.EnterState();

        if (SwitchState != null)
        {
            SwitchState.Invoke(stateKey);
        }

        IsTransitioningState = false;
    }
}

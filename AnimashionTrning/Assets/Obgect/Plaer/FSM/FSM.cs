using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class FSM
{
    public FsmState LastState { get; private set; }
    private FsmState StateCurrent { get; set; }

    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (StateCurrent != null && StateCurrent.GetType() == type)
        {
            return;
        }

        if(_states.TryGetValue(type, out var state)) 
        {
            StateCurrent?.Exit();

            LastState = StateCurrent;
            StateCurrent = state;

            StateCurrent?.Enter();
        }
    }

    public void Update()
    {
        StateCurrent?.Update();
    }

}

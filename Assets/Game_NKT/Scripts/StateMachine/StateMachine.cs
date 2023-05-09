using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.UI.GridLayoutGroup;

public class StateMachine<T> where T : Characters
{
    private IState<T> currentState;
    private T typeClass;

    public void ChangeState<TState>(TState state) where TState : IState<T>
    {
        if (currentState != null)
        {
            currentState.OnExit(typeClass);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(typeClass);
        }
    }

    public void UpdateState(T owner)
    {
        if (currentState != null)
        {
            currentState.OnExecute(owner);
        }
    }

    public void SetOwner(T owner)
    {
        typeClass = owner;
    }
}

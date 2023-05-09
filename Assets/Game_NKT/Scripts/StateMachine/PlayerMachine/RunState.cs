using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = true;
        t.ChangeAnim("Run");
    }

    public void OnExecute(Player t)
    {
        t.Moving();

        if (!t.IsMove())
        {
            t.currentState.ChangeState(new IdleState());
            return;
        }
    }

    public void OnExit(Player t)
    {

    }
}

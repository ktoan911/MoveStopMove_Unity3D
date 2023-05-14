using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = false;

        t.ChangeAnim("Idle");
    }

    public void OnExecute(Player t)
    {   
        if(t.IsMove())
        {
            t.currentState.ChangeState(new RunState());
            return;
        }

        if (t.IsAttack)
        {
            t.ChangeRotation();

            t.currentState.ChangeState(new AttackState());
            return;

        }
    }

    public void OnExit(Player t)
    {

    }

}

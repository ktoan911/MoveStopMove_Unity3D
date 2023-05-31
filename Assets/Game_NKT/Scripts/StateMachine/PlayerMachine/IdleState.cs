using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Player>
{
    private float timeDelayAttack;

    public void OnEnter(Player t)
    {
        t.IsMoving = false;

        timeDelayAttack = 0.35f;

        t.ChangeAnim("Idle");
    }

    public void OnExecute(Player t)
    {
        if (t.CheckAllIsAround())
        {
            t.IsAttack = true;
        }
        else t.IsAttack = false;


        if (t.IsMove())
        {
            t.currentState.ChangeState(new RunState());
            return;
        }
        if (t.IsAttack)
        {
            timeDelayAttack -= Time.deltaTime;
            if (timeDelayAttack > 0f) return;

            t.ChangeRotation();

            t.currentState.ChangeState(new AttackState());
            return;
        }

    }

    public void OnExit(Player t)
    {

    }

}

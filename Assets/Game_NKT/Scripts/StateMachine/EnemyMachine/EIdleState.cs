using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : IState<Enemy>
{
    private float timeDelayAttack;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        timeDelayAttack = 0.35f;

        t.StopMove();

        t.ChangeAnim("Idle");
    }

    public void OnExecute(Enemy t)
    {
        if (t.CheckAllIsAround())
        {
            t.IsAttack = true;
        }
        else t.IsAttack = false;

        if (t.IsAttack)
        {
            timeDelayAttack -= Time.deltaTime;
            if (timeDelayAttack > 0f) return;

            t.ChangeRotation();

            t.currentState.ChangeState(new EAttackState());

            return;
        }

        t.SeekForTarget();

        if (t.IsFoundCharacter)
        {
            t.agent.isStopped = false;

            t.currentState.ChangeState(new ERunState());

            return;
        }
    }

    public void OnExit(Enemy t)
    {
        
    }
}

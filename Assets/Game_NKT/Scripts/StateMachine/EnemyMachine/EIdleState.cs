using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        t.StopMove();

        t.ChangeAnim("Idle");
    }

    public void OnExecute(Enemy t)
    {
        if (t.IsAttack)
        {
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

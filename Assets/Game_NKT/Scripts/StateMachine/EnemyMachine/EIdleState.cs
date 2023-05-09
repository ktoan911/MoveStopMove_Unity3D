using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : IState<Enemy>
{
    private float timer;
    private float currentTime;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        timer = 2.5f;
        currentTime = 0;

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

        currentTime += Time.deltaTime;

        if (currentTime > timer)
        {
            t.SeekForTarget();
        }
         
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

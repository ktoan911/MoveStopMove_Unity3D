using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERunState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {
        t.IsMoving = true;


        t.ChangeAnim("Run");
    }

    public void OnExecute(Enemy t)
    {
        if (t.IsGotoTarget() || t.IsAttack)
        {
            t.currentState.ChangeState(new EIdleState());
            return;
        }
    }

    public void OnExit(Enemy t)
    {
        
    }
}

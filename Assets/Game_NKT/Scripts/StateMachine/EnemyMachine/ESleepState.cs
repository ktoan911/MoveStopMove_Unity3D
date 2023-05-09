using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ESleepState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {
        t.ChangeAnim("Idle");
    }

    public void OnExecute(Enemy t)
    {
        t.currentState.ChangeState(new EIdleState());
    }

    public void OnExit(Enemy t)
    {
        t.IsAttack = false;
    }
}

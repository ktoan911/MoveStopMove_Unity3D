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
        if (GameManager.Ins.IsPlayGame) // GManager phụ trách việc chuyển sang idle
        {
            t.currentState.ChangeState(new EIdleState());

            t.SpawnWayPoint(t.transform.position); // sinh ra waypoint
        }
    }

    public void OnExit(Enemy t)
    {
        t.IsAttack = false;
    }
}

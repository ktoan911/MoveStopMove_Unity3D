using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = false;

        t.ChangeAnim("DanceSkin");
    }

    public void OnExecute(Player t)
    {
        if (GameManager.Ins.IsPlayGame)  // GManager phụ trách việc chuyển sang idle
        {
            t.currentState.ChangeState(new IdleState());

            t.SpawnWayPoint(t.transform.position); // sinh ra waypoint
        }
    }

    public void OnExit(Player t)
    {

    }

}

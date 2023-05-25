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
        if (GameManager.Ins.IsPlayGame)
        {
            t.currentState.ChangeState(new IdleState());
        }
    }

    public void OnExit(Player t)
    {

    }

}

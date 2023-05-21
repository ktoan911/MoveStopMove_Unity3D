using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Player>
{
    private float timeDelayDead = 0.7f;

    public void OnEnter(Player t)
    {
        t.IsMoving= false;

        t.ChangeAnim("Dead");
    }

    public void OnExecute(Player t)
    {
        //timeDelayDead -= Time.deltaTime;
        //if (timeDelayDead > 0) return;

    }

    public void OnExit(Player t)
    {

    }
}

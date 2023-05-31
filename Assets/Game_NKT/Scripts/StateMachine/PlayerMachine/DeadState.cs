using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Player>
{
    private float timeDelayDead = 0.3f;

    public void OnEnter(Player t)
    {
        t.IsMoving= false;

        t.SpawnVFX();

        t.ChangeAnim("Dead");

        PlatformManager.Ins.PlatformCheckWhenCharacterDead();
    }

    public void OnExecute(Player t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;

        t.DeadUI(t.characterKill);

        t.gameObject.SetActive(false);

        GameManager.Ins.IsPlayGame = false;

        t.UpdateCoin(t.coinUp, true);

    }

    public void OnExit(Player t)
    {

    }
}

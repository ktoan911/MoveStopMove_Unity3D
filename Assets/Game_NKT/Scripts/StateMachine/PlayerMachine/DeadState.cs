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

        SoundManager.Ins.LoseSoundPlay();

        if (t.skinShieldID != -1)
        {
            t.coinUp = t.coinUp * ChangeSkin.Ins.GetShieldSOByID(t.skinShieldID).UpGold;
        }
    }

    public void OnExecute(Player t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;

        t.UpdateCoin(t.coinUp, true);

        t.DeadUI(t.characterKill, t.coinUp);

        t.gameObject.SetActive(false);

        GameManager.Ins.IsPlayGame = false;


    }

    public void OnExit(Player t)
    {

    }
}

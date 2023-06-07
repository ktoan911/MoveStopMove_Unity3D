using UnityEngine;

public class WinState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = false;

        t.ChangeAnim("DanceWin");

        SoundManager.Ins.WinSoundPlay();

        if (t.skinShieldID != -1)
        {
            t.coinUp = t.coinUp * ChangeSkin.Ins.GetShieldSOByID(t.skinShieldID).UpGold;
        }

        t.UpdateCoin(t.coinUp, true);

        t.WinUI(t.coinUp);
    }

    public void OnExecute(Player t)
    {
       


    }

    public void OnExit(Player t)
    {

    }
}

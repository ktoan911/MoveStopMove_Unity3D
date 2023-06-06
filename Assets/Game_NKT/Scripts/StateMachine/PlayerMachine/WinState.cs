using UnityEngine;

public class WinState : IState<Player>
{
    public void OnEnter(Player t)
    {
        t.IsMoving = false;

        t.WinUI();

        t.ChangeAnim("DanceWin");

        SoundManager.Ins.WinSoundPlay();
    }

    public void OnExecute(Player t)
    {
        

    }

    public void OnExit(Player t)
    {

    }
}

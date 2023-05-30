using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    [SerializeField] private FloatingJoystick joystick;
    public void SetupOnOpen(Player player)
    {
        player.SetupJoystick(joystick);

        player.DeadUI += LoseUI;

        player.WinUI = WinUI;
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
        Close(0);
    }

    public void LoseUI(Characters character)
    {
        UIManager.Ins.OpenUI<LoseScreen>();

        LoseScreenDialog.Ins.SetTextLoseScreen(character);

        Close(0);
    }

    public void WinUI()
    {
        UIManager.Ins.OpenUI<WinScreen>();

        Close(0);
    }
}

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
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }

    public void LoseUI()
    {
        UIManager.Ins.OpenUI<LoseScreen>();

        Close(0);
    }
}

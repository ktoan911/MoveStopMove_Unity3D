using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    [SerializeField] private FloatingJoystick joystick;
    public void SetupOnOpen(Player player)
    {
        player.SetupJoystick(joystick);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();

        //GameManager.Ins.PauseGame();
    }
}

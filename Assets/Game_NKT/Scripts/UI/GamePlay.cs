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

    public void LoseUI(Characters character)
    {
        UIManager.Ins.OpenUI<LoseScreen>();

        LoseScreenDialog.Ins.SetTextLoseScreen(character.characterName);

        Close(0);
    }
}

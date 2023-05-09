using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);
        GameManager.Ins.ResumeGame();
        Close(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
        Close(0);
    }

    public void ShopButton()
    {
        UIManager.Ins.OpenUI<Shop>();
        Close(0);
    }
}

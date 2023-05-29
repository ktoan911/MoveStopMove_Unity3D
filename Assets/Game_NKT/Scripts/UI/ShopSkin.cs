using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkin : UICanvas
{
    public void BackMenuButton()
    {
        Player player = GameManager.Ins.Player;

        UIManager.Ins.OpenUI<MainMenu>();

        MenuDialog.Ins.SetCoinText(player.Coins);

        MainCamera.Ins.MainMenuCamera();

        Close(0);
    }
}

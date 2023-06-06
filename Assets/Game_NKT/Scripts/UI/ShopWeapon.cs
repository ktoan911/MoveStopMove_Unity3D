using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapon : UICanvas
{
   // private Player player = GameManager.Ins.Player;  ???????

    public void BackMenuButton()
    {
        Player player = GameManager.Ins.Player;

        UIManager.Ins.OpenUI<MainMenu>().CheckMute();

        MenuDialog.Ins.SetCoinText(player.Coins);

        Close(0);
    }

}

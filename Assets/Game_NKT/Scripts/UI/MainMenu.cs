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

    public void ShopWeaponButton()
    {
        UIManager.Ins.OpenUI<ShopWeapon>();

        ShopWeaponUI.Ins.SetCoinText(GameManager.Ins.Player.Coins);

        Close(0);
    }

    public void ShopSkinButton()
    {
        UIManager.Ins.OpenUI<ShopSkin>();

        ShopSkinDialog.Ins.UpdateSkinHairUI();

        ShopSkinDialog.Ins.SetCoinText(GameManager.Ins.Player.Coins);

        Close(0);
    }


}

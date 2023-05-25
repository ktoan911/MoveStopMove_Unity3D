using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);

        GamePlayDialog.Ins.OnInit();

        //GameManager.Ins.ResumeGame();
        GameManager.Ins.IsPlayGame = true;

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

        CameraManager.Ins.PlayerViewInShopSkin();

        Close(0);
    }


}

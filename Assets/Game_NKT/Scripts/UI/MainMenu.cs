using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    [SerializeField] private GameObject OffMusic;

    [SerializeField] private GameObject OnMusic;

    public void CheckMute()
    {
        if (SoundManager.Ins.IsMute)
        {
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
        }
        else
        {
            OnMusic.SetActive(true);
            OffMusic.SetActive(false);
        }

    }


    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);

        GamePlayDialog.Ins.OnInit();

        MainCamera.Ins.PlayCamera();
        
        GameManager.Ins.IsPlayGame = true;

        SoundManager.Ins.PlayGameMusic();

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

        MainCamera.Ins.ShopSkinCamera();

        Close(0);
    }


}

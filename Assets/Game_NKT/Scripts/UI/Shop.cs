using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : UICanvas
{
    public void PlayButton()
    {
        GameManager.Ins.ResumeGame();

        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);
        Close(0);
    }

    public void RightButton()
    {
        WeaponImage.Ins.ChangeWeapon(true);
    }

    public void LeftButton()
    {
        WeaponImage.Ins.ChangeWeapon(false);
    }

}

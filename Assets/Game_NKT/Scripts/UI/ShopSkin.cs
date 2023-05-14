using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkin : UICanvas
{
    public void BackMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }
}

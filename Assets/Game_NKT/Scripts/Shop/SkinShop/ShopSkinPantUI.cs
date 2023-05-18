using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinPantUI : ShopSkinUI<SkinPantsSO>
{
    [SerializeField] private Button btn;

    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        BuySkinButton.Ins.SetShopSkinTag(ShopSkinTag.pant);

        BuySkinButton.Ins.SetSkinPantSO(skinSO);


        shopItemID = skinSO.ID;

        bool isUnlocked = Pref.GetBool(PrefConst.CUR_SKINPANT_ID + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurPantId) this.ShopSkinItemAction("UnEqqip");
            else this.ShopSkinItemAction("Select");
        }
        else
        {
            this.ShopSkinItemAction(skinSO.price.ToString());
        }

    }


    public override void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinPantsS0[currentIndex].hud;

        skinSO = SOManager.Ins.skinPantsS0[currentIndex];
    }


}

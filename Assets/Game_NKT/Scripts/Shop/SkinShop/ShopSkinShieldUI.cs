using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinShieldUI : ShopSkinUI<SkinShieldSO>
{
    [SerializeField] private Button btn;

    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        BuySkinButton.Ins.SetShopSkinTag(ShopSkinTag.shield);

        BuySkinButton.Ins.SetSkinShieldSO(skinSO);

        shopItemID = skinSO.ID;

        bool isUnlocked = Pref.GetBool(PrefConst.CUR_SKINSHIELD_ID + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurShieldId) this.ShopSkinItemAction("UnEqqip");
            else this.ShopSkinItemAction("Select");
        }
        else
        {
            this.ShopSkinItemAction(skinSO.price.ToString());
        }
    }


    public override void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinShieldS0[currentIndex].hud;

        skinSO = SOManager.Ins.skinShieldS0[currentIndex];

    }


}




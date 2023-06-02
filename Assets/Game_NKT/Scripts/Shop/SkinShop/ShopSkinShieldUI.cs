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
            if (shopItemID == Pref.CurShieldId)
            {
                this.ShopSkinItemAction("UnEquip", frame, ShopManager.Ins.imageButtonUnEquip, EquipText);
            }
            else
            {
                this.ShopSkinItemAction("Select", frame, ShopManager.Ins.imageButtonSelect, EquipText);
            }
        }
        else
        {
            this.ShopSkinItemAction(skinSO.price.ToString(), frame, ShopManager.Ins.imageButtonBuy, EquipText);
        }
    }


    public override void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinShieldS0[currentIndex].hud;

        skinSO = SOManager.Ins.skinShieldS0[currentIndex];

        this.CheckOwnItem();

    }

    public override void CheckOwnItem()
    {
        base.CheckOwnItem();

        shopItemID = skinSO.ID;

        bool isUnlocked = Pref.GetBool(PrefConst.CUR_SKINSHIELD_ID + shopItemID);

        if (isUnlocked)
        {
            iconBlock.SetActive(false);
        }
        else
        {
            iconBlock.SetActive(true);
        }

    }


}




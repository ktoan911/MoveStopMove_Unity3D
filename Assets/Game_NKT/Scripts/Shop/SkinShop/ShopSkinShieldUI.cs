using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinShieldUI : MonoBehaviour
{
    public Image hud;

    public SkinShieldSO skinShieldSO;

    public UnityAction<string> ShopSkinItemAction;

    [SerializeField] private Button btn;

    private int shopItemID;


    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        BuySkinButton.Ins.SetShopSkinTag(ShopSkinTag.shield);

        BuySkinButton.Ins.SetSkinShieldSO(skinShieldSO);

        shopItemID = skinShieldSO.IDSkin;

        bool isUnlocked = Pref.GetBool(PrefConst.CUR_SKINSHIELD_ID + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurShieldId) this.ShopSkinItemAction("UnEqqip");
            else this.ShopSkinItemAction("Select");
        }
        else
        {
            this.ShopSkinItemAction(skinShieldSO.skinPrice.ToString());
        }
    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinShieldS0[currentIndex].hud;

        skinShieldSO = SOManager.Ins.skinShieldS0[currentIndex];

    }


}




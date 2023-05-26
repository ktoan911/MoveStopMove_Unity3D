using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ShopSkinTag { pant, shield, hair, none}


public class BuySkinButton : Singleton<BuySkinButton>
{
    private SkinHatSO skinHairSO;

    private SkinShieldSO skinShieldSO;

    private SkinPantsSO skinPantsSO;

    [SerializeField] private Button btnBuy;

    public int skinID;

    public ShopSkinTag shopSkinTag = ShopSkinTag.none;

    public UnityAction<string> ShopSkinItemBuyAction;


    private void Start()
    {
        btnBuy.onClick.AddListener(SetModel);
    }

    private void SetModel()
    {
        Player player = GameManager.Ins.Player;

        if (shopSkinTag == ShopSkinTag.pant && skinPantsSO != null)
        {
            bool isUnlocked = Pref.GetBool(PrefConst.SKINPANT_PEFIX + skinPantsSO.ID);
            if(isUnlocked)
            {
                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;

                Pref.CurPantId = skinPantsSO.ID;

                player.ChangePant(skinPantsSO.ID);
            }
            else if (player.Coins >= skinPantsSO.price)
            {
                Pref.SetBool(PrefConst.SKINPANT_PEFIX + skinPantsSO.ID, true);

                Pref.CurPantId = skinPantsSO.ID;

                player.ChangePant(skinPantsSO.ID);

                player.UpdateCoin(skinPantsSO.price, false);

                ShopSkinDialog.Ins.SetCoinText(player.Coins);

                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;
            }
        }

        else if (shopSkinTag == ShopSkinTag.hair && skinHairSO != null)
        {
            bool isUnlocked = Pref.GetBool(PrefConst.SKINHAIR_PEFIX + skinHairSO.ID);
            if (isUnlocked)
            {
                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;

                Pref.CurHairId = skinHairSO.ID;

                player.ChangeHair(skinHairSO.ID);
            }
            else if (player.Coins >= skinHairSO.price)
            {
                Pref.SetBool(PrefConst.SKINHAIR_PEFIX + skinHairSO.ID, true);

                Pref.CurHairId = skinHairSO.ID;

                player.ChangeHair(skinHairSO.ID);

                player.UpdateCoin(skinHairSO.price, false);

                ShopSkinDialog.Ins.SetCoinText(player.Coins);

                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;
            }
        }

        else if (shopSkinTag == ShopSkinTag.shield && skinShieldSO != null)
        {
            bool isUnlocked = Pref.GetBool(PrefConst.SKINSHIELD_PEFIX + skinShieldSO.ID);
            if (isUnlocked)
            {
                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;

                Pref.CurShieldId = skinShieldSO.ID;

                player.ChangeShield(skinShieldSO.ID);
            }
            else if (player.Coins >= skinShieldSO.price)
            {
                Pref.SetBool(PrefConst.SKINSHIELD_PEFIX + skinShieldSO.ID, true);

                Pref.CurShieldId = skinShieldSO.ID;

                player.ChangeShield(skinShieldSO.ID);

                player.UpdateCoin(skinShieldSO.price, false);

                ShopSkinDialog.Ins.SetCoinText(player.Coins);

                this.ShopSkinItemBuyAction("UnEqip");

                btnBuy.image.sprite = ShopManager.Ins.imageButtonUnEquip;
            }
        }
    }


    public void SetShopSkinTag(ShopSkinTag tag)
    {
        this.shopSkinTag = tag;
    }
    public void SetSkinHairSO(SkinHatSO skinSO)
    {
        this.skinHairSO = skinSO;
    }
    public void SetSkinShieldSO(SkinShieldSO skinSO)
    {
        this.skinShieldSO = skinSO;
    }
    public void SetSkinPantSO(SkinPantsSO skinSO)
    {
        this.skinPantsSO = skinSO;
    }
}

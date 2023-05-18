using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ShopSkinTag { pant, shield, hair, none}


public class BuySkinButton : Singleton<BuySkinButton>
{
    public int skinID;

    private SkinHatSO skinHairSO;

    private SkinShieldSO skinShieldSO;

    private SkinPantsSO skinPantsSO;

    public ShopSkinTag shopSkinTag = ShopSkinTag.none;

    [SerializeField] private Button btn;

    public UnityAction<string> ShopSkinItemBuyAction;


    private void Start()
    {
        btn.onClick.AddListener(SetModel);
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

                Pref.CurPantId = skinPantsSO.ID;

                player.ChangePant(skinPantsSO.ID);
            }
            else if (player.Coins >= skinPantsSO.price)
            {
                //GameManager.Ins.Player.ChangeSpeed(12);

                Pref.SetBool(PrefConst.SKINPANT_PEFIX + skinPantsSO.ID, true);

                Pref.CurPantId = skinPantsSO.ID;

                player.ChangePant(skinPantsSO.ID);

                player.UpdateCoin(skinPantsSO.price, false);

                ShopSkinDialog.Ins.SetCoinText(player.Coins);

                this.ShopSkinItemBuyAction("UnEqip");
            }
        }

        else if (shopSkinTag == ShopSkinTag.hair && skinHairSO != null)
        {
            bool isUnlocked = Pref.GetBool(PrefConst.SKINHAIR_PEFIX + skinHairSO.ID);
            if (isUnlocked)
            {
                this.ShopSkinItemBuyAction("UnEqip");

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
            }
        }

        else if (shopSkinTag == ShopSkinTag.shield && skinShieldSO != null)
        {
            bool isUnlocked = Pref.GetBool(PrefConst.SKINSHIELD_PEFIX + skinShieldSO.ID);
            if (isUnlocked)
            {
                this.ShopSkinItemBuyAction("UnEqip");

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

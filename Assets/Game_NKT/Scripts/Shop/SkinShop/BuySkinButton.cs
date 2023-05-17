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

        if (shopSkinTag == ShopSkinTag.pant && player.Coins >= skinPantsSO.skinPrice && skinPantsSO != null)
        {
            Pref.SetBool(PrefConst.CUR_SKINPANT_ID + skinPantsSO.IDSkin, true);

            Pref.CurPantId = skinPantsSO.IDSkin;

            player.ChangePant(skinPantsSO.IDSkin);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);

            this.ShopSkinItemBuyAction("UnEqip");


            //check đã có chưa nếu chưa có thì trừ tiền
            // if (!Pref.GetBool(PrefConst.SKINPANT_PEFIX + skinPantsSO.IDSkin)) return; tại sao cái này lại sai !!!!!!!!!!
            if (Pref.GetBool(PrefConst.SKINPANT_PEFIX + skinPantsSO.IDSkin)) return;

            player.UpdateCoin(skinPantsSO.skinPrice, false);

        }

        else if (shopSkinTag == ShopSkinTag.hair && player.Coins >= skinHairSO.skinPrice && skinHairSO != null)
        {
            Pref.SetBool(PrefConst.CUR_SKINHAIR_ID + skinHairSO.IDSkin, true);

            Pref.CurHairId= skinHairSO.IDSkin;  

            player.ChangeHair(skinHairSO.IDSkin);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);

            this.ShopSkinItemBuyAction("UnEqip");


            if (Pref.GetBool(PrefConst.SKINHAIR_PEFIX + skinHairSO.IDSkin)) return;

            player.UpdateCoin(skinHairSO.skinPrice, false);
        }

        else if (shopSkinTag == ShopSkinTag.shield && player.Coins >= skinShieldSO.skinPrice && skinShieldSO != null)
        {
            Pref.SetBool(PrefConst.CUR_SKINSHIELD_ID + skinShieldSO.IDSkin, true);

            Pref.CurShieldId= skinShieldSO.IDSkin;

            player.ChangeShield(skinShieldSO.IDSkin);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);

            this.ShopSkinItemBuyAction("UnEqip");


            if (Pref.GetBool(PrefConst.SKINSHIELD_PEFIX + skinShieldSO.IDSkin)) return;

            player.UpdateCoin(skinShieldSO.skinPrice, false);
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

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


    private void Start()
    {
        btn.onClick.AddListener(SetData);
    }

    private void SetData()
    {
        Player player = GameManager.Ins.Player;

        if (shopSkinTag == ShopSkinTag.pant && player.Coins >= skinPantsSO.skinPrice && skinPantsSO != null)
        {
            player.Coins -= skinPantsSO.skinPrice;

            player.SetSkinPantID(skinPantsSO.IDSkin);

            player.ChangePant();

            ShopSkinDialog.Ins.SetCoinText(player.Coins);
        }

        else if (shopSkinTag == ShopSkinTag.hair && player.Coins >= skinHairSO.skinPrice && skinHairSO != null)
        {
            player.Coins -= skinHairSO.skinPrice;

            player.SetSkinHairID(skinHairSO.IDSkin);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);
        }

        else if (shopSkinTag == ShopSkinTag.shield && player.Coins >= skinShieldSO.skinPrice && skinShieldSO != null)
        {
            player.Coins -= skinShieldSO.skinPrice;

            player.SetSkinShieldID(skinShieldSO.IDSkin);

            ShopSkinDialog.Ins.SetCoinText(player.Coins);
        }

        //else Debug.Log("null SO SkinShop");
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
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinPantUI : MonoBehaviour
{
    public Image hud;

    public SkinPantsSO skinPantSO;

    public UnityAction<string> ShopSkinItemAction;

    [SerializeField] private Button btn;

    private int shopItemID;


    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        BuySkinButton.Ins.SetShopSkinTag(ShopSkinTag.pant);

        BuySkinButton.Ins.SetSkinPantSO(skinPantSO);


        shopItemID = skinPantSO.IDSkin;

        bool isUnlocked = Pref.GetBool(PrefConst.CUR_SKINPANT_ID + shopItemID);

        if (isUnlocked)
        {
            if (shopItemID == Pref.CurPantId) this.ShopSkinItemAction("UnEqqip");
            else this.ShopSkinItemAction("Select");
        }
        else
        {
            this.ShopSkinItemAction(skinPantSO.skinPrice.ToString());
        }

    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinPantsS0[currentIndex].hud;

        skinPantSO = SOManager.Ins.skinPantsS0[currentIndex];
    }


}

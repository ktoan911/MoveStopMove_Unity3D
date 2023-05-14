using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinShieldUI : MonoBehaviour
{
    public Image hud;

    public int priceItem;

    public int itemID;

    public UnityAction<int> ShopSkinItemAction;

    [SerializeField] private Button btn;


    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        this.ShopSkinItemAction(priceItem);
    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinShieldS0[currentIndex].hud;

        priceItem = SOManager.Ins.skinShieldS0[currentIndex].skinPrice;

        itemID = SOManager.Ins.skinShieldS0[currentIndex].IDSkin;

    }


}




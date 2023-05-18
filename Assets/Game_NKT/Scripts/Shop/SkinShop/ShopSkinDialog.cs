using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkinDialog : Singleton<ShopSkinDialog>
{
    public Transform gridRoot;

    public TMP_Text priceText;

    public ShopSkinHairUI itemHairUIPrefab;

    public ShopSkinPantUI itemPantUIPrefab;

    public ShopSkinShieldUI itemShieldUIPrefab;

    [SerializeField] private TMP_Text coinText;

    public void UpdateSkinUI<T, U>(List<T> items, U itemUIPrefab) where T : ParentSO where U : ShopSkinUI<T>
    {
        BuySkinButton.Ins.ShopSkinItemBuyAction += UpdatePriceText;

        if (items == null || items.Count < 1 || !itemUIPrefab || !gridRoot) return;

        this.ClearChildren();

        for (int i = 0; i < items.Count; i++)
        {
            T item = items[i];

            if (item != null)
            {
                U itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);

                itemUIClone.transform.SetParent(gridRoot);
                itemUIClone.transform.localPosition = Vector3.zero;
                itemUIClone.transform.localScale = Vector3.one;
                itemUIClone.SetInfoItem(i);
                itemUIClone.ShopSkinItemAction += UpdatePriceText;
            }
            else
            {
                Debug.LogError("NULL ITEM");
            }
        }
    }

    public void UpdateSkinHairUI()
    {
        List<SkinHatSO> items = SOManager.Ins.skinHairS0;
        UpdateSkinUI(items, itemHairUIPrefab);
    }

    public void UpdateSkinPantsUI()
    {
        List<SkinPantsSO> items = SOManager.Ins.skinPantsS0;
        UpdateSkinUI(items, itemPantUIPrefab);
    }

    public void UpdateSkinShieldUI()
    {
        List<SkinShieldSO> items = SOManager.Ins.skinShieldS0;
        UpdateSkinUI(items, itemShieldUIPrefab);
    }


    public void ClearChildren()
    {
        if(!gridRoot || gridRoot.childCount <= 0) return;

        for(int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);

            if(child) Destroy(child.gameObject);
        }
    }

    private void UpdatePriceText(string priceText)
    {
        this.priceText.text = priceText;
    }

    public void HairButton()
    {
        this.UpdateSkinHairUI();
    }
    public void PantsButton()
    {
        this.UpdateSkinPantsUI();
    }
    public void ShieldButton()
    {
        this.UpdateSkinShieldUI();
    }


    public void SetCoinText(int coin)
    {
        if (this.coinText == null) Debug.Log("null player");

        if(coin < 0) coin = 0;

        this.coinText.text = coin.ToString();
    }

  
}




//public void UpdateSkinHairUI()
//{
//    BuySkinButton.Ins.ShopSkinItemBuyAction += UpdatePriceText;

//    List<SkinHatSO> items = SOManager.Ins.skinHairS0;

//    if (items == null || items.Count < 1 || !itemHairUIPrefab || !gridRoot) return;

//    this.ClearChildren();

//    for (int i = 0; i < items.Count; i++)
//    {
//        int idx = i;

//        SkinHatSO item = items[i];

//        if (item != null)
//        {
//            ShopSkinHairUI itemUIClone = Instantiate(itemHairUIPrefab, Vector3.zero, Quaternion.identity);

//            itemUIClone.transform.SetParent(gridRoot);

//            itemUIClone.transform.localPosition = Vector3.zero;

//            itemUIClone.transform.localScale = Vector3.one;

//            itemUIClone.SetInfoItem(i);

//            itemUIClone.ShopSkinItemAction += UpdatePriceText;


//        }

//        else { Debug.LogError("nULL ITEM"); }
//    }
//}

//public void UpdateSkinPantsUI()
//{
//    List<SkinPantsSO> items = SOManager.Ins.skinPantsS0;

//    if (items == null || items.Count < 1 || !itemPantUIPrefab || !gridRoot) return;

//    this.ClearChildren();

//    for (int i = 0; i < items.Count; i++)
//    {
//        int idx = i;

//        SkinPantsSO item = items[i];

//        if (item != null)
//        {
//            ShopSkinPantUI itemUIClone = Instantiate(itemPantUIPrefab, Vector3.zero, Quaternion.identity);

//            itemUIClone.transform.SetParent(gridRoot);

//            itemUIClone.transform.localPosition = Vector3.zero;

//            itemUIClone.transform.localScale = Vector3.one;

//            itemUIClone.SetInfoItem(i);

//            itemUIClone.ShopSkinItemAction += UpdatePriceText;

//        }

//        else { Debug.LogError("nULL ITEM"); }
//    }
//}

//public void UpdateSkinShieldUI()
//{
//    List<SkinShieldSO> items = SOManager.Ins.skinShieldS0;

//    if (items == null || items.Count < 1 || !itemPantUIPrefab || !gridRoot) return;

//    this.ClearChildren();

//    for (int i = 0; i < items.Count; i++)
//    {
//        int idx = i;

//        SkinShieldSO item = items[i];

//        if (item != null)
//        {
//            ShopSkinShieldUI itemUIClone = Instantiate(itemShieldUIPrefab, Vector3.zero, Quaternion.identity);

//            itemUIClone.transform.SetParent(gridRoot);

//            itemUIClone.transform.localPosition = Vector3.zero;

//            itemUIClone.transform.localScale = Vector3.one;

//            itemUIClone.SetInfoItem(i);

//            itemUIClone.ShopSkinItemAction += UpdatePriceText;

//        }

//        else { Debug.LogError("nULL ITEM"); }
//    }
//}


using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
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

    [SerializeField] private Button buyButton;

    private GameObject curFrame;

    public Button curEquipTypeButton;

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
                itemUIClone.ShopSkinItemAction += UpdateButton;
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


    private void UpdateButton(string priceText, GameObject currrentFrame, Sprite buttonImage)
    {
        if(curFrame != null)
        {
            curFrame.SetActive(false);
        }

        UpdatePriceText(priceText);

        buyButton.image.sprite = buttonImage;


        this.curFrame = currrentFrame;

        curFrame.SetActive(true);
    }

    public void HairButton()
    {
        if(curEquipTypeButton!= null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 120f / 255); 
        }

        this.UpdateSkinHairUI();
    }
    public void PantsButton()
    {
        if (curEquipTypeButton != null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 120f / 255);
        }

        this.UpdateSkinPantsUI();
    }
    public void ShieldButton()
    {
        if (curEquipTypeButton != null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 120f / 255);
        }

        this.UpdateSkinShieldUI();
    }


    public void SetCoinText(int coin)
    {
        if (this.coinText == null) Debug.Log("null player");

        if(coin < 0) coin = 0;

        this.coinText.text = coin.ToString();
    }

  
}





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

    private ShopSkinTag shopSkinTag;

    private GameObject curTextEquipMent;

    private GameObject pastTextEquipMent;

    public Button curEquipTypeButton;

    private int prefCurTypeSkin;

    public void UpdateSkinUI<T, U>(List<T> items, U itemUIPrefab) where T : ParentSO where U : ShopSkinUI<T>
    {
        BuySkinButton.Ins.ShopSkinItemBuyAction += UpdateEventBuyItem;

        if (items == null || items.Count < 1 || !itemUIPrefab || !gridRoot) return;

        this.ClearChildren();


        switch (shopSkinTag)
        {
            case ShopSkinTag.hair:
                prefCurTypeSkin = Pref.CurHairId;
                break;
            case ShopSkinTag.pant:
                prefCurTypeSkin = Pref.CurPantId;
                break;
            case ShopSkinTag.shield:
                prefCurTypeSkin = Pref.CurShieldId;
                break;
        }


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

                if (item.ID == prefCurTypeSkin)
                {
                    curTextEquipMent = itemUIClone.EquipText;

                    curTextEquipMent.SetActive(true);
                }

            }
            else
            {
                Debug.LogError("NULL ITEM");
            }
        }
    }

    public void UpdateSkinHairUI()
    {
        shopSkinTag = ShopSkinTag.hair;

        List<SkinHatSO> items = SOManager.Ins.skinHairS0;
        UpdateSkinUI(items, itemHairUIPrefab);
    }

    public void UpdateSkinPantsUI()
    {
        shopSkinTag = ShopSkinTag.pant;

        List <SkinPantsSO> items = SOManager.Ins.skinPantsS0;
        UpdateSkinUI(items, itemPantUIPrefab);
    }

    public void UpdateSkinShieldUI()
    {
        shopSkinTag = ShopSkinTag.shield;

        List<SkinShieldSO> items = SOManager.Ins.skinShieldS0;
        UpdateSkinUI(items, itemShieldUIPrefab);
    }

    private void ClearChildren()
    {
        if(!gridRoot || gridRoot.childCount <= 0) return;

        for(int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);

            if(child) Destroy(child.gameObject);
        }
    }

    private void UpdateEventBuyItem(string priceText)
    {
        this.priceText.text = priceText;

        if(pastTextEquipMent) pastTextEquipMent.SetActive(false);

        if(curTextEquipMent != null) curTextEquipMent.SetActive(true);


    }

    private void UpdateButton(string priceText, GameObject currrentFrame, Sprite buttonImage, GameObject EquipText)
    {
        if(curFrame != null)
        {
            curFrame.SetActive(false);
        }

        this.priceText.text = priceText;

        buyButton.image.sprite = buttonImage;
        this.curFrame = currrentFrame;

        this.pastTextEquipMent = curTextEquipMent;

        this.curTextEquipMent= EquipText;

        curFrame.SetActive(true);
    }

    public void HairButton()
    {
        if(curEquipTypeButton!= null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 121f / 255); 
        }

        this.UpdateSkinHairUI();
    }
    public void PantsButton()
    {
        if (curEquipTypeButton != null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 121f / 255);
        }

        this.UpdateSkinPantsUI();
    }
    public void ShieldButton()
    {
        if (curEquipTypeButton != null)
        {
            curEquipTypeButton.image.color = new Color(0, 0, 0, 121f / 255);
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





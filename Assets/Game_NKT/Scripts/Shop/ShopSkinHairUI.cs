using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinHairUI : MonoBehaviour
{
    public Image hud;

    public SkinHatSO skinHairSO;

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
        this.ShopSkinItemAction(skinHairSO.skinPrice);
    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinHairS0[currentIndex].hud;

        skinHairSO = SOManager.Ins.skinHairS0[currentIndex];

    }


}

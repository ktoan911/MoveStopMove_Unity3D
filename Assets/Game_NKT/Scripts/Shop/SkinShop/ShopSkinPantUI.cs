using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinPantUI : MonoBehaviour
{
    public Image hud;

    public SkinPantsSO skinPantsSO;

    public UnityAction<int> ShopSkinItemAction;

    [SerializeField] private Button btn;


    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        this.ShopSkinItemAction(skinPantsSO.skinPrice);

        BuySkinButton.Ins.SetShopSkinTag(ShopSkinTag.pant);

        BuySkinButton.Ins.SetSkinPantSO(skinPantsSO);
    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinPantsS0[currentIndex].hud;

        skinPantsSO = SOManager.Ins.skinPantsS0[currentIndex];
    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShopSkinShieldUI : MonoBehaviour
{
    public Image hud;

    public SkinShieldSO skinShieldSO;

    public UnityAction<int> ShopSkinItemAction;

    [SerializeField] private Button btn;


    private void Start()
    {
        btn.onClick.AddListener(ResetButton);
    }

    private void ResetButton()
    {
        this.ShopSkinItemAction(skinShieldSO.skinPrice);
    }


    public void SetInfoItem(int currentIndex)
    {
        hud.sprite = SOManager.Ins.skinShieldS0[currentIndex].hud;

        skinShieldSO = SOManager.Ins.skinShieldS0[currentIndex];

    }


}




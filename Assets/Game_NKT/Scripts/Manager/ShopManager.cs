using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1:03:22

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private Player player;


    public Sprite imageButtonBuy;
    public Sprite imageButtonSelect;
    public Sprite imageButtonUnEquip;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(PrefConst.WEAPON_PEFIX + 0))
        {
            Pref.SetBool(PrefConst.WEAPON_PEFIX + 0, true);
        }

        player.SetInitalEquip();
    }
}
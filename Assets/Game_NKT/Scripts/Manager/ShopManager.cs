using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

//1:03:22

public class ShopManager : Singleton<ShopManager>
{
    public ShopWeaponItem[] WeaponItems;

    private void Start()
    {
        if (WeaponItems == null || WeaponItems.Length < 1) return;

        for(int i = 0; i < WeaponItems.Length; i++)
        {
            var item = WeaponItems[i];

            if (item != null)
            {
                if(i == 0)
                {
                    Pref.SetBool(PrefConst.WEAPON_PEFIX + i, true); //weapon 0
                }

                else
                {
                    //weapon 1
                    if(!PlayerPrefs.HasKey(PrefConst.WEAPON_PEFIX + i))
                    {
                        Pref.SetBool(PrefConst.WEAPON_PEFIX + i, false);
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class ShopWeaponItem
{
    public int price;

    public Sprite hud;

    public int ID;

}

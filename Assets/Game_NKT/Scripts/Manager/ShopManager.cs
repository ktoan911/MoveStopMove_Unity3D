//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////1:03:22

//public class ShopManager : Singleton<ShopManager>
//{

//    public List<WeaponSO> WeaponItems = SOManager.Ins.weaponS0;

//    private void Start()
//    {
//        if (WeaponItems == null || WeaponItems.Count < 1) return;

//        for (int i = 0; i < WeaponItems.Count; i++)
//        {
//            var item = WeaponItems[i];

//            if (item != null)
//            {
//                if (i == 0)
//                {
//                    Pref.SetBool(PrefConst.WEAPON_PEFIX + i, true); //weapon 0
//                }

//                else
//                {
//                    //weapon 1
//                    if (!PlayerPrefs.HasKey(PrefConst.WEAPON_PEFIX + i))
//                    {
//                        Pref.SetBool(PrefConst.WEAPON_PEFIX + i, false);
//                    }
//                }
//            }
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//chỉ lấy dữ liệu nên ko cần khởi tạo trong game => không cần kế thừa monobehaviour
public class Pref 
{
    public static int CurWeaponId
    {
        set => PlayerPrefs.SetInt(PrefConst.CUR_EQIP_ID, value);

        get => PlayerPrefs.GetInt(PrefConst.CUR_EQIP_ID);
    }

    public static int Coins
    {
        set => PlayerPrefs.SetInt(PrefConst.COIN_KEY, value);

        get => PlayerPrefs.GetInt(PrefConst.COIN_KEY);
    }


    public static void SetBool(string key , bool isOn)
    {
        if (isOn) PlayerPrefs.SetInt(key, 1);

        else PlayerPrefs.SetInt(key, 0);
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false ;
    }
}

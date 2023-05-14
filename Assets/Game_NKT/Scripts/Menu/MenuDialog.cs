using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDialog : Singleton<MenuDialog>
{
    [SerializeField] private TMP_Text coinText;

    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }
}

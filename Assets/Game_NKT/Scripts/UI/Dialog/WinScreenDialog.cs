using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenDialog : Singleton<WinScreenDialog>
{
    public TMP_Text coinText;

    public void SetTextWinScreen(int coinUp)
    {
        coinText.text = coinUp.ToString();
    }
}

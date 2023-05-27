using UnityEngine.UI;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class MenuDialog : Singleton<MenuDialog>
{
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private TMP_InputField textNameInput;

    [SerializeField] private TMP_Text textInitialPriceText;

    private void Start()
    {
        textInitialPriceText.text = Pref.NamePlayer;
    }

    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }

    public void ChangeName()
    {
        GameManager.Ins.Player.ChangeNamePlayer(textNameInput.text);

        Pref.NamePlayer = textNameInput.text;
    }
}

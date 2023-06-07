using TMPro;
using UnityEngine;

public class LoseScreenDialog : Singleton<LoseScreenDialog> 
{
    [SerializeField] private TMP_Text whoKill;

    [SerializeField] private TMP_Text rankText;

    [SerializeField] private TMP_Text coinText;


    public void SetTextLoseScreen(Characters character, int coinUp)
    {
        whoKill.text = character.characterName;

        whoKill.color = character.materialCharacter.material.color;

        rankText.text = "# " + PlatformManager.Ins.numberOfCharacter.ToString();

        coinText.text = coinUp.ToString();
    }
}

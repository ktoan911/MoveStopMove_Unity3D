using TMPro;
using UnityEngine;

public class LoseScreenDialog : Singleton<LoseScreenDialog> 
{
    [SerializeField] private TMP_Text whoKill;

    [SerializeField] private TMP_Text rankText;
 
    public void SetTextLoseScreen(Characters character)
    {
        whoKill.text = character.characterName;

        whoKill.color = character.materialCharacter.material.color;

        rankText.text = PlatformManager.Ins.numberOfEnemies.ToString();


    }
}

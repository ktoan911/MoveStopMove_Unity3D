using TMPro;
using UnityEngine;

public class LoseScreenDialog : Singleton<LoseScreenDialog> 
{
    [SerializeField] private TMP_Text noti;

    [SerializeField] private TMP_Text rankText;
 
    public void SetTextLoseScreen(string name)
    {
        noti.text = name;

        rankText.text = PlatformManager.Ins.numberOfEnemies.ToString();


    }
}

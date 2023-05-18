using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayDialog : Singleton<GamePlayDialog>
{
    [SerializeField] private TMP_Text numberEnemiesText;

    public void OnInit()
    {
        this.SetNumberEnemiesText(GameManager.Ins.numberOfEnemies);
    }
    public void SetNumberEnemiesText(int numberEnemies)
    {
        numberEnemiesText.text = numberEnemies.ToString();
    }
}

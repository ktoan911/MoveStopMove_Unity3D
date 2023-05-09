using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void ContinueButton()
    {
        GameManager.Ins.ResumeGame();

        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);
        Close(0);
    }
}

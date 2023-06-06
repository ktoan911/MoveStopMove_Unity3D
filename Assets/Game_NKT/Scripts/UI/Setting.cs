using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : UICanvas
{
    [SerializeField] private GameObject OffMusic;

    [SerializeField] private GameObject OnMusic;

    public void ContinueButton()
    {
        UIManager.Ins.OpenUI<GamePlay>().SetupOnOpen(GameManager.Ins.Player);

        GamePlayDialog.Ins.OnInit();

        Close(0);
    }

    public void BackToHomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        GameManager.Ins.IsPlayGame = false;
    }

    public void CheckMute()
    {
        if (SoundManager.Ins.IsMute)
        {
            OnMusic.SetActive(false);
            OffMusic.SetActive(true);
        }
        else
        {
            OnMusic.SetActive(true);
            OffMusic.SetActive(false);
        }

    }
}

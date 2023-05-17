using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    public Player Player { get => player; }

    [SerializeField] private Enemy enemy;
    public Enemy Enemy { get => enemy; }

    protected void Awake()
    {
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }
        UIManager.Ins.OpenUI<MainMenu>();

        Pref.Coins = 1000;

       // PlayerPrefs.DeleteAll();

        this.SetStartSkinPlayer();

        MenuDialog.Ins.SetCoinText(player.Coins);

        this.PauseGame();


    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        
    }

    public void SetCoinPlayer()
    {
        player.Coins = Pref.Coins;
    }


    //vũ khí mặc định có ban đầu để id bằng 0 
    private void SetStartSkinPlayer()
    {
        this.SetCoinPlayer();

        //bool isUnlockWraponIntial = Pref.GetBool(PrefConst.WEAPON_PEFIX + 0);

        //if (!isUnlockWraponIntial)
        //{
        //    Pref.SetBool(PrefConst.WEAPON_PEFIX + 0, true);
        //    player.ChangeWeapon(0);
        //}


    }



}

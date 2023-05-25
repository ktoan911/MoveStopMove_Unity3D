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

    private bool isPlayGame = false;
    public bool IsPlayGame { get => isPlayGame; set => isPlayGame = value; }

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

        this.SetCoinPlayer();

        MenuDialog.Ins.SetCoinText(player.Coins);

        //this.PauseGame();
    }

    private void Update()
    {
        CheckGameWin();

    }

    public void SetCoinPlayer()
    {
        player.Coins = Pref.Coins;
    }

    public void CheckGameWin()
    {
        if(PlatformManager.Ins.numberOfEnemies <= 0 )
        {
            PlatformManager.Ins.numberOfEnemies = 0;

            GamePlayDialog.Ins.SetNumberEnemiesText(PlatformManager.Ins.numberOfEnemies);

            this.IsPlayGame = false;
        }
    }




}

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

    public int numberOfEnemies;

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

       // Pref.Coins = 1000;

        this.SetCoinPlayer();

        MenuDialog.Ins.SetCoinText(player.Coins);

        this.PauseGame();
    }

    private void Start()
    {
        numberOfEnemies = 100;
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

    public void OnUpdateNumberEnemies()
    {
        --numberOfEnemies;

        GamePlayDialog.Ins.SetNumberEnemiesText(numberOfEnemies);
    }



}

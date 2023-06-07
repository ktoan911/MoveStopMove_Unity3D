using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;

    [SerializeField] private Enemy enemy;

    private bool isPlayGame = false;

    private bool isWinGame;
    public bool IsPlayGame { get => isPlayGame; set => isPlayGame = value; }
    public Player Player { get => player; }

    public Enemy Enemy { get => enemy; }
    public bool IsWinGame { get => isWinGame; set => isWinGame = value; }

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

        SoundManager.Ins.IsMute = Pref.GetBool(PrefConst.MUTE);

        SoundManager.Ins.MuteMusic(SoundManager.Ins.IsMute);

        UIManager.Ins.OpenUI<MainMenu>().CheckMute();

        this.SetCoinPlayer();

        MenuDialog.Ins.SetCoinText(player.Coins);

        this.isWinGame = false;

      
    }

    private void Update()
    {
        if(isWinGame)
        {
            WinGame();
            isWinGame = false;
        }
    }

    public void SetCoinPlayer()
    {
        player.Coins = Pref.Coins;
    }

    public void WinGame()
    {
        GamePlayDialog.Ins.SetNumberCharactersText(PlatformManager.Ins.numberOfCharacter);

        MainCamera.Ins.MainMenuCamera();

        this.IsPlayGame = false;

        this.Player.currentState.ChangeState(new WinState());
    }






}

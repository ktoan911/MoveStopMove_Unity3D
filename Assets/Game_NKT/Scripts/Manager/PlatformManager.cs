using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    private bool isLastSpawn;

    public int numberEnemiesDead;

    public int numberOfEnemies;

    public List<Enemy> enemyList = new List<Enemy>();

    public List<string> listNameEnemy = new List<string>();


    private void Awake()
    {
        listNameEnemy = new List<string>()
        {
            "John", "Emma", "Michael", "Sophia", "Daniel", "Olivia", "James", "Ava", "William", "Isabella",
            "Benjamin", "Mia", "Mason", "Charlotte", "Elijah", "Amelia", "Oliver", "Harper", "Jacob", "Evelyn",
            "Lucas", "Abigail", "Alexander", "Emily", "Daniel", "Elizabeth", "Matthew", "Sofia", "Henry", "Avery",
            "Joseph", "Ella", "Samuel", "Scarlett", "Jackson", "Grace", "Sebastian", "Chloe", "David", "Victoria",
            "Carter", "Madison", "Wyatt", "Lily", "Andrew", "Layla", "Jayden", "Zoe", "Gabriel", "Penelope"
        };

        isLastSpawn = true;
    }
    private void Start()
    {
        EnemySpawner.Instance.SpawnEnemiesInitial(this.listNameEnemy);

        numberOfEnemies = 100;

    }
    private void Update()
    {
        this.ReSpawnEnemies();

        this.CheckGameWin();
    }

    private void ReSpawnEnemies()
    {
        if (this.numberOfEnemies <= EnemySpawner.Instance.spawnPos.Count) return;

        if (numberEnemiesDead >= 7 && GameManager.Ins.IsPlayGame)
        {
            EnemySpawner.Instance.ReSpawn(8, this.listNameEnemy);
            numberEnemiesDead = 0;
        }
    }

    public void ResetListEnemy(Enemy enemy, bool isUp)
    {
        if(isUp)
        {
            this.enemyList.Add(enemy);
        }
        else
        {
            this.enemyList.Remove(enemy);
        }
    }

    public void OnUpdateNumberEnemies()
    {
        --numberOfEnemies;

        numberEnemiesDead++;

        GamePlayDialog.Ins.SetNumberEnemiesText(numberOfEnemies);
    }

    private void CheckGameWin()
    {
        if(this.numberOfEnemies == EnemySpawner.Instance.spawnPos.Count && isLastSpawn)
        {
            EnemySpawner.Instance.LastSpawn(EnemySpawner.Instance.spawnPos.Count - this.enemyList.Count - 1, listNameEnemy);

            isLastSpawn = false;
        }

        if (this.numberOfEnemies <= 0)
        {
            this.numberOfEnemies = 0;

            GamePlayDialog.Ins.SetNumberEnemiesText(this.numberOfEnemies);

            GameManager.Ins.IsPlayGame = false;

            GameManager.Ins.Player.currentState.ChangeState(new WinState());
        }
    }
}

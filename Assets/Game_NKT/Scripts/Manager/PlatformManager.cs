using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlatformManager : Singleton<PlatformManager>
{
    private bool isLastSpawn;

    public int numberEnemiesDead;

    public int numberOfCharacter;

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

        numberOfCharacter = 100;

    }

    private void ReSpawnEnemies()
    {
        if (!isLastSpawn) return;

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
        --numberOfCharacter;

        numberEnemiesDead++;

        GamePlayDialog.Ins.SetNumberCharactersText(numberOfCharacter);
    }

    private void CheckGameWin()
    {
        if(this.numberOfCharacter - 1 <= EnemySpawner.Instance.spawnPos.Count && isLastSpawn)
        {
            isLastSpawn = false;

            int numberLastSpawn = EnemySpawner.Instance.spawnPos.Count - this.enemyList.Count;

            EnemySpawner.Instance.LastSpawn(numberLastSpawn, listNameEnemy);

            this.numberOfCharacter = EnemySpawner.Instance.spawnPos.Count + 1;
        }

        if (this.numberOfCharacter <= 1) //Player Only
        {
            this.numberOfCharacter = 1;

            GameManager.Ins.IsWinGame = true;
        }
    }

    public void PlatformCheckWhenCharacterDead()
    {
        this.ReSpawnEnemies();

        this.CheckGameWin();
    }
}

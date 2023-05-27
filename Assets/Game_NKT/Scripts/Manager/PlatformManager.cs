using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public int numberEnemiesDead;

    public int numberOfEnemies;

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
    }
    private void Start()
    {
        EnemySpawner.Instance.SpawnEnemiesInitial(this.listNameEnemy);

        numberOfEnemies = 100;

    }
    private void Update()
    {
        this.ReSpawnEnemies();
    }

    private void ReSpawnEnemies()
    {
        if(numberEnemiesDead >= 7 && GameManager.Ins.IsPlayGame)
        {
            EnemySpawner.Instance.ReSpawn(8, this.listNameEnemy);
            numberEnemiesDead = 0;
        }
    }

    public void OnUpdateNumberEnemies()
    {
        --numberOfEnemies;

        numberEnemiesDead++;

        GamePlayDialog.Ins.SetNumberEnemiesText(numberOfEnemies);
    }
}

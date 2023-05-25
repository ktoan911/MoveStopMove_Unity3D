using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public int numberEnemiesDead;

    public int numberOfEnemies;

    private void Start()
    {
        EnemySpawner.Instance.SpawnEnemies();

        numberOfEnemies = 100;

        Debug.Log(numberOfEnemies);
    }
    private void Update()
    {
        this.ReSpawnEnemies();
    }

    private void ReSpawnEnemies()
    {
        if(numberEnemiesDead >= 7 && GameManager.Ins.IsPlayGame)
        {
            EnemySpawner.Instance.ReSpawn(8);
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

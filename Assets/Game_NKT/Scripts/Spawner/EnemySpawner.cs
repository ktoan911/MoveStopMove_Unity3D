using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    private int numberSpawn;

    [SerializeField] private Enemy enemyPrfab;

    [SerializeField] protected List<Transform> reSpawnPos = new List<Transform>();

    public List<Transform> spawnPos = new List<Transform>();

    private void Awake()
    {
        instance = this;

        this.numberSpawn = 0;
    }
    public Vector3 GetClosestPointOnNavmesh(Vector3 pos)
    {
        NavMeshHit myNavHit;
        if (NavMesh.SamplePosition(pos, out myNavHit, 100, -1))
        {
            return myNavHit.position;
        }
        return pos;
    }
    public Transform SpawnPos()
    {
        if (spawnPos.Count < numberSpawn + 1)
        {
            return null;
        }
        return spawnPos[numberSpawn];
    }

    public Transform ReSpawnPos()
    {
        if (reSpawnPos.Count < numberSpawn + 1)
        {
            return null;
        }
        return reSpawnPos[numberSpawn];
    }

    protected void OnSpawn(List<string> listName)
    {
        for (int i = 0; i < spawnPos.Count; i++)
        {
            Enemy enemyPool = SimplePool.Spawn<Enemy>(enemyPrfab, GetClosestPointOnNavmesh(SpawnPos().position), SpawnPos().rotation);

            PlatformManager.Ins.ResetListEnemy(enemyPool, true);

            enemyPool.RandomName(listName);

            enemyPool.OnInit();
            numberSpawn++;
        }

        this.numberSpawn = 0;

    }

    public void LastSpawn(int numberLastSpawn, List<string> listName)
    {
        if (numberLastSpawn <= 0) return;

        for (int i = 0; i < numberLastSpawn; i++)
        {
            Enemy enemyPool = SimplePool.Spawn<Enemy>(enemyPrfab, GetClosestPointOnNavmesh(ReSpawnPos().position), ReSpawnPos().rotation);

            PlatformManager.Ins.ResetListEnemy(enemyPool, true);

            enemyPool.RandomName(listName);

            enemyPool.OnInit();
            this.numberSpawn++;
        }
    }

    public void SpawnEnemiesInitial(List<string> listName)
    {
        this.OnSpawn(listName);
    }

    public void ReSpawn(int numberSpawn, List<string> listName)
    {
        for (int i = 0; i < numberSpawn - 1; i++)
        {
            Enemy enemyPool = SimplePool.Spawn<Enemy>(enemyPrfab, GetClosestPointOnNavmesh(ReSpawnPos().position), ReSpawnPos().rotation);

            PlatformManager.Ins.ResetListEnemy(enemyPool, true);
            enemyPool.RandomName(listName);

            enemyPool.OnInit();
            this.numberSpawn++;
        }

        this.numberSpawn = 0;
    }


}

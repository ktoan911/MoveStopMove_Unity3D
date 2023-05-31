using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    private static GiftSpawner instance;

    private float timeSpawn;

    [SerializeField] private List<Transform> giftPosList= new List<Transform>();

    [SerializeField] private Gift giftPrefab;

    public static GiftSpawner Instance { get => instance; }

    private void Awake()
    {
        instance = this;

        timeSpawn = Random.Range(12, 20);
    }

    private void Update()
    {
        if (!GameManager.Ins.IsPlayGame) return;

        if (giftPosList.Count <= 0) return;

        timeSpawn -= Time.deltaTime;
        if (timeSpawn > 0) return;

        this.GiftRandomSpawner();
    }

    private Transform RandomPosition()
    {
        if (giftPosList.Count <= 0) return null;

        Transform giftPosTmp;

        do
        {
            int random = Random.Range(0, giftPosList.Count);

            giftPosTmp = giftPosList[random];

            this.giftPosList.Remove(giftPosList[random]);
        } while (giftPosTmp == null);

        return giftPosTmp;
    }

    public void GiftRandomSpawner()
    {
        Gift giftPool = SimplePool.Spawn<Gift>(giftPrefab, RandomPosition().position, Quaternion.identity);

        giftPool.OnInit();

        timeSpawn = Random.Range(12, 20);
    }
}

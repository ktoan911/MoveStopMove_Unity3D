using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : Spawner
{
    private static WeaponSpawner instance;
    public static WeaponSpawner Instance { get => instance; }

    private void Awake()
    {
        instance = this;
    }


    public Weapon GetWeaponByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.weaponS0.Count; i++)
        {
            if (SOManager.Ins.weaponS0[i].IDWeapon == id) return SOManager.Ins.weaponS0[i].weaponPrefab;
        }

        return SOManager.Ins.weaponS0[0].weaponPrefab;
    }

    public void SpawnPlayerWeapon(Vector3 direction, Vector3 pos, Quaternion rot)
    {
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponByID(1), pos , rot);
        weaponPool.OnInit();
        weaponPool.SetDirection(direction);
    }

    public void SpawnEnemyWeapon(int Eid, Vector3 direction, Vector3 pos, Quaternion rot)
    {
         
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponByID(Eid), pos, rot);
        weaponPool.OnInit();
        weaponPool.SetDirection(direction);
    }
}

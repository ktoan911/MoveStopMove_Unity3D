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


    public WeaponSO GetWeaponSOByID(int id)
    {
        for (int i = 0; i < SOManager.Ins.weaponS0.Count; i++)
        {
            if (SOManager.Ins.weaponS0[i].IDWeapon == id) return SOManager.Ins.weaponS0[i];
        }

        return SOManager.Ins.weaponS0[0];
    }

    public void SpawnPlayerWeapon(int weaponID, Vector3 direction, Vector3 pos, Quaternion rot,float attackRange)
    {
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponSOByID(weaponID).weaponPrefab, pos , rot);
        weaponPool.OnInit();
        weaponPool.SetTimeDestroy(attackRange);
        weaponPool.SetDirection(direction);
    }

    public void SpawnEnemyWeapon(int Eid, Vector3 direction, Vector3 pos, Quaternion rot, float attackRange)
    {
         
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponSOByID(Eid).weaponPrefab, pos, rot);
        weaponPool.OnInit();
        weaponPool.SetTimeDestroy(attackRange);
        weaponPool.SetDirection(direction);
    }
}

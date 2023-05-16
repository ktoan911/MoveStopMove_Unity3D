using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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


    public void ChangeModelWeaponPlayer(Transform parentSpawn, int id )
    {
        ClearPastWeapon(parentSpawn);

        WeaponSO weaponSO = this.GetWeaponSOByID(id);

        Vector3 localPosition = weaponSO.weaponModel.transform.localPosition;
        Quaternion localRot = weaponSO.weaponModel.transform.localRotation;

        WeaponModel weaponModelPool = SimplePool.Spawn<WeaponModel>(weaponSO.weaponModel, Vector3.zero, Quaternion.identity);
        weaponModelPool.gameObject.transform.SetParent(parentSpawn);

        weaponModelPool.gameObject.transform.localPosition = localPosition;

        weaponModelPool.gameObject.transform.localRotation = localRot;
    }

    private void ClearPastWeapon(Transform parentSpawn)
    {
        if (!parentSpawn || parentSpawn.childCount <= 0) return;

        for (int i = 0; i < parentSpawn.childCount; i++)
        {
            var child = parentSpawn.GetChild(i);

            if (child) Destroy(child.gameObject);
        }
    }

}

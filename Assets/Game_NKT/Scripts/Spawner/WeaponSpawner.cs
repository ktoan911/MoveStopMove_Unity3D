using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
            if (SOManager.Ins.weaponS0[i].ID == id) return SOManager.Ins.weaponS0[i];
        }

        return SOManager.Ins.weaponS0[0];
    }

    public void SpawnPlayerWeapon(Player player)
    {
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponSOByID(player.weaponID).weaponPrefab, player.throwPoint.position, Quaternion.identity);
        weaponPool.transform.rotation = Quaternion.LookRotation(player.TargetDirection());
        weaponPool.OnInit();
        weaponPool.SetTimeDestroy(player.attackRange);
        weaponPool.SetDataWeapon(player.TargetDirection(), player);

        if (player.IsUpScaleWeapon)
        {
            weaponPool.UpScaleWeapon();
            player.IsUpScaleWeapon = false;
            player.UpScaleCharacter(player.currentScale);
            ChangepropertiesCharacter.Ins.PlayerResetAfterGift(player);
        }
    }

    public void SpawnEnemyWeapon(Enemy enemy)
    {
         
        Weapon weaponPool = SimplePool.Spawn<Weapon>(GetWeaponSOByID(enemy.enemyIDWeapon).weaponPrefab, enemy.throwPoint.position, Quaternion.identity);
        weaponPool.transform.rotation = Quaternion.LookRotation(enemy.TargetDirection());
        weaponPool.OnInit();
        weaponPool.SetTimeDestroy(enemy.attackRange);
        weaponPool.SetDataWeapon(enemy.TargetDirection(),enemy);

        if (enemy.IsUpScaleWeapon)
        {
            weaponPool.UpScaleWeapon();
            enemy.IsUpScaleWeapon = false;
            enemy.UpScaleCharacter(enemy.currentScale);
            ChangepropertiesCharacter.Ins.EnemyResetAfterGift(enemy);
        }
    }


    public void ChangeModelWeaponPlayer(Player player, Transform parentSpawn, int id )
    {
        ClearPastWeapon(parentSpawn);

        WeaponSO weaponSO = this.GetWeaponSOByID(id);

        Vector3 localPosition = weaponSO.weaponModel.transform.localPosition;
        Quaternion localRot = weaponSO.weaponModel.transform.localRotation;

        WeaponModel weaponModelPool = SimplePool.Spawn<WeaponModel>(weaponSO.weaponModel, Vector3.zero, Quaternion.identity);

        if(id != 0) weaponModelPool.OnInit(player, 1f + weaponSO.percentUpRange);

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

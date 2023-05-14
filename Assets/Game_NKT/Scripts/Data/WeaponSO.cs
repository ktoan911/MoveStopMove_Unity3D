using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponSO", menuName = "WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public Weapon weaponPrefab;

    public GameObject weaponModel;

    public string weaponName;

    public int IDWeapon;

    public int weaponRange;

    public int weaPonPrice;

    public Sprite hud;
}


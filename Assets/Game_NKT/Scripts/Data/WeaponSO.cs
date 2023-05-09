using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponSO", menuName = "WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public Weapon weaponPrefab;

    public float speedWeapon;

    public int IDWeapon;

    public int weaponRange;
}


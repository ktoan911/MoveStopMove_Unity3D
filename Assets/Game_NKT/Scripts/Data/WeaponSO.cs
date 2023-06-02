using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponSO", menuName = "WeaponSO")]
public class WeaponSO : ParentSO
{
    public Weapon weaponPrefab;

    public WeaponModel weaponModel;

    public string weaponName;

    public float percentUpRange;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinShieldsSO", menuName = "SkinShieldsSO")]
public class SkinShieldSO : ScriptableObject
{
    public GameObject skinShieldPrefab;

    public GameObject skinShield;

    public int IDSkin;

    public int skinRange;

    public int skinPrice;

    public Sprite hud;
}


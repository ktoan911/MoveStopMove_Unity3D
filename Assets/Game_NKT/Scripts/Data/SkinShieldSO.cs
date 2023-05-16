using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinShieldsSO", menuName = "SkinShieldsSO")]
public class SkinShieldSO : ScriptableObject
{
    public Skin skinShieldPrefab;

    public int IDSkin;

    public int skinRange;

    public int skinPrice;

    public Sprite hud;
}


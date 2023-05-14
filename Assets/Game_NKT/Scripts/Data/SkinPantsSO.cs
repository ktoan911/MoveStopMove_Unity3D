using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinPantsSO", menuName = "SkinPantsSO")]
public class SkinPantsSO : ScriptableObject
{
    public Material skinPantPrefab;

    public int IDSkin;

    public int skinRange;

    public int skinPrice;

    public Sprite hud;
}


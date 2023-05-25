using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ColorData", menuName = "ColorData")]
public class ColorData : ScriptableObject
{
    [SerializeField] public List<Material> matsList = new List<Material>();

    public Material GetColor(int numberEnum)
    {
        return matsList[numberEnum];
    }
}


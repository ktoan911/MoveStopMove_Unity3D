using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public struct InfoLevel
{
    public int level;

    public int scale;
}

[CreateAssetMenu(fileName = "LevelChangeData", menuName = "LevelChangeData")]
public class LevelChangeData : ScriptableObject
{
    public List<int> levels = new List<int>();

}


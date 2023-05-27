using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public struct InfoLevel
{
    public int level;

    public int scale;
}

[CreateAssetMenu(fileName = "LevelChangeData", menuName = "LevelChangeData")]
public class LevelChangeData : ScriptableObject
{
    [SerializeField] public List<InfoLevel> levels = new List<InfoLevel>();

    public void AddData(InfoLevel newData)
    {
        levels.Add(newData);
    }

    public void RemoveData(InfoLevel dataToRemove)
    {
        levels.Remove(dataToRemove);
    }
}






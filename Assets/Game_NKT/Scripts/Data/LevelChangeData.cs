using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[System.Serializable]
public struct InfoLevel
{
    public int level;

    public float scale;
}

[CreateAssetMenu(fileName = "LevelChangeData", menuName = "LevelChangeData")]
public class LevelChangeData : ScriptableObject
{
    [SerializeField] public List<InfoLevel> levels = new List<InfoLevel>();

    public float GetScale(int level, float pastScale)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if(level == levels[i].level)
            {
                return levels[i].scale;
            }
        }

        return pastScale;
    }
}






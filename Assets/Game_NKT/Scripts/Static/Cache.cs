using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;


public class Cache
{

    private static Dictionary<float, WaitForSeconds> m_WFS = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWFS(float key)
    {
        if (!m_WFS.ContainsKey(key))
        {
            m_WFS[key] = new WaitForSeconds(key);
        }

        return m_WFS[key];
    }

    //------------------------------------------------------------------------------------------------------------


    private static Dictionary<Collider, PlayerCollider> player = new Dictionary<Collider, PlayerCollider>();

    public static PlayerCollider GetPlayerBody(Collider collider)
    {
        if (!player.ContainsKey(collider))
        {
            player.Add(collider, collider.GetComponent<PlayerCollider>());
        }

        return player[collider];
    }


    private static Dictionary<Collider, EnemyCollider> enemy = new Dictionary<Collider, EnemyCollider>();

    public static EnemyCollider GetEnemyBody(Collider collider)
    {
        if (!enemy.ContainsKey(collider))
        {
            enemy.Add(collider, collider.GetComponent<EnemyCollider>());
        }

        return enemy[collider];
    }
}

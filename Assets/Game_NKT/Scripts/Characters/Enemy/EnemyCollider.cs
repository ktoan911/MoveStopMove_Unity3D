using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyCollider : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            this.enemy.currentState.ChangeState(new EDeadState());
        }

        if(other.CompareTag("Enemy"))
        {
            this.enemy.GotoPoint(new Vector3(0, 0, 0));
        }
    }
}
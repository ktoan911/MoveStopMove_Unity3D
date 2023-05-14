using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackState : IState<Enemy>
{
    private float timeAttack;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        timeAttack = 1f;

        t.ChangeAnim("Attack");

        WeaponSpawner.Instance.SpawnEnemyWeapon(t.enemyIDWeapon,t.TargetDirection(), t.transform.position + Vector3.up + t.transform.forward, Quaternion.identity, t.attackRange);
    }

    public void OnExecute(Enemy t)
    {
        timeAttack -= Time.deltaTime;
        if (timeAttack > 0) return;

        t.IsAttack = false;
        t.currentState.ChangeState(new EIdleState());

        return;
    }

    public void OnExit(Enemy t)
    {
        
    }
}

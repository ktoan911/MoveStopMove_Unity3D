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

        if (t.characterInRange.Count > 0)
        {
            WeaponSpawner.Instance.SpawnEnemyWeapon(t);
        }
       
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

using Unity.VisualScripting;
using UnityEngine;

public class EDeadState : IState<Enemy>
{
    private float timeDelayDead = 0.3f;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        t.ChangeAnim("Dead");

        t.SpawnVFX();

        PlatformManager.Ins.OnUpdateNumberEnemies();

        PlatformManager.Ins.ResetListEnemy(t, false);

        PlatformManager.Ins.listNameEnemy.Add(t.characterName);

        PlatformManager.Ins.PlatformCheckWhenCharacterDead();
    }

    public void OnExecute(Enemy t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;
        SimplePool.Despawn(t);
        t.waypointClone.OnDespawn();
    }

    public void OnExit(Enemy t)
    {
       
    }
}

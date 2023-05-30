using Unity.VisualScripting;
using UnityEngine;

public class EDeadState : IState<Enemy>
{
    private float timeDelayDead = 0.7f;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        t.ChangeAnim("Dead");

        t.SpawnVFX();

        //t.RemoveCharacterInRangeAction(t.colliderCharacter.gameObject);

        PlatformManager.Ins.OnUpdateNumberEnemies();

        PlatformManager.Ins.ResetListEnemy(t, false);

        PlatformManager.Ins.listNameEnemy.Add(t.characterName);
    }

    public void OnExecute(Enemy t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;
        t.OnDespawn();
        t.waypointClone.OnDespawn();
    }

    public void OnExit(Enemy t)
    {
       
    }
}

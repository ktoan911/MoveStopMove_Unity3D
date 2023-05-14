using UnityEngine;

public class EDeadState : IState<Enemy>
{
    private float timeDelayDead = 0.7f;

    public void OnEnter(Enemy t)
    {
        t.IsMoving = false;

        t.ChangeAnim("Dead");
    }

    public void OnExecute(Enemy t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;

        t.OnDespawn();
    }

    public void OnExit(Enemy t)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Player>
{
    private float timeDelayDead = 1f;

    public void OnEnter(Player t)
    {
        t.IsMoving= false;

       // t.RemoveCharacterInRangeAction(t.colliderCharacter.gameObject);

        t.ChangeAnim("Dead");
    }

    public void OnExecute(Player t)
    {
        timeDelayDead -= Time.deltaTime;
        if (timeDelayDead > 0) return;

        t.DeadUI(t.characterKill);
        t.gameObject.SetActive(false);

    }

    public void OnExit(Player t)
    {

    }
}

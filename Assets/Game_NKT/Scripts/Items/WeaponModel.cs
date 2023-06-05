using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : GameUnit
{
    public override void OnDespawn()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInit()
    {
        throw new System.NotImplementedException();
    }

    public void OnInit(Player t, float curScale)
    {
        ChangepropertiesCharacter.Ins.ChangePlayerAttackRange(curScale, t);
    }

    public void OnInit(Enemy t, float curScale)
    {
        ChangepropertiesCharacter.Ins.ChangeEnemyAttackRange(curScale, t);
    }

}

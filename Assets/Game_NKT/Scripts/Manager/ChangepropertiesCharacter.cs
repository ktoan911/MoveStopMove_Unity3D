using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangepropertiesCharacter : Singleton<ChangepropertiesCharacter>
{
    public void ChangePlayerAttackRange(float percentChange, Player player)
    {
        player.attackRange = player.attackRange * (1 + percentChange / 100);

        player.playerAttackRange.ChangeAttackRange(player.attackRange);

        player.circleRange.ChangeAttackRangeCircle(player.attackRange);
    }

    public void ChangeEnemyAttackRange(float percentChange, Enemy enemy)
    {
        enemy.attackRange = enemy.attackRange * (1 + percentChange / 100);
        enemy.enemyAttackRange.ChangeAttackRange(enemy.attackRange);
       
    }

    public void ChangeSpeed(float percentChange, Characters character)
    {
        character.Speed = character.Speed * (1 + percentChange / 100);
    }


}

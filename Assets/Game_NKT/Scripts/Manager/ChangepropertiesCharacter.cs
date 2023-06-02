using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangepropertiesCharacter : Singleton<ChangepropertiesCharacter>
{
    public void ChangePlayerAttackRange(float rateChange, Player player)
    {
        player.attackRange = 5 * rateChange;

        player.circleRange.ChangeAttackRangeCircle(player.attackRange);
    }

    public void ChangeEnemyAttackRange(float rateChange, Enemy enemy)
    {
        enemy.attackRange = 5 * rateChange;     
    }

    public void ChangeSpeed(float percentChange, Characters character)
    {
        character.Speed = character.Speed * (1 + percentChange / 100);
    }


}

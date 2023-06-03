using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangepropertiesCharacter : Singleton<ChangepropertiesCharacter>
{
    private float playerPastRate = 1;
    private float enemyPastRate = 1;

    private float playerPastRateGift ;
    private float enemyPastRateGift ;

    public void ChangePlayerAttackRange(float rateChange, Player player)
    {
        player.attackRange /= playerPastRate;

        playerPastRate = rateChange;

        player.attackRange *= rateChange;

        player.circleRange.ChangeAttackRangeCircle(player.attackRange);
    }

    public void ChangeEnemyAttackRange(float rateChange, Enemy enemy)
    {
        enemy.attackRange /= enemyPastRate;

        enemyPastRate = rateChange;

        enemy.attackRange = 5 * rateChange;     
    }

    public void ChangeSpeed(float percentChange, Characters character)
    {
        character.Speed = character.Speed * (1 + percentChange / 100);
    }

    public void ChangePlayerAttackRangeGift(float newRange, Player player)
    {
        playerPastRateGift = player.attackRange;

        player.attackRange = newRange;

        player.circleRange.ChangeAttackRangeCircle(player.attackRange);
    }

    public void PlayerResetAfterGift(Player player)
    {
        player.attackRange = playerPastRateGift;

        player.circleRange.ChangeAttackRangeCircle(player.attackRange);
    }

    public void ChangeEnemyAttackRangeGift(float newRange, Enemy enemy)
    {
        enemyPastRateGift = enemy.attackRange;

        enemy.attackRange = newRange;
    }

    public void EnemyResetAfterGift(Enemy enemy)
    {
        enemy.attackRange = enemyPastRateGift;
    }


}

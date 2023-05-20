using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : Singleton<EquipManager>
{
    public void ChangePlayerAttackRange(float percentChange, Player player)
    {
        player.playerRange.ChangeAttackRange(player.attackRange * (1 + percentChange / 100));

        player.range.ChangeAttackRangeCircle(player.attackRange * (1 + percentChange / 100));
    }

    public void ChangeSpeed(float percentChange, Characters character)
    {
        character.Speed = character.Speed * (1 + percentChange / 100);
    }


}

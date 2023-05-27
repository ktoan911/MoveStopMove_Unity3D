using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private SphereCollider sphereCollider;


    //Nếu muốn cộng dồn thì phải thay đổi giá trị player.atkrange nhưng mà game
    //này chưa đến mức cộng dồn
    public void ChangeAttackRange(float attackRange)
    {
        if (sphereCollider != null)
        {
            sphereCollider.radius = attackRange / 10;
        }
        else
        {
            Debug.LogError("No Sphere Collider component found!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyTmp = Cache.GetEnemyBody(other).enemy;

            player.IsAttack = true;

            player.characterInRange.Add(other.gameObject);

            enemyTmp.RemoveCharacterInRangeAction += player.RemoveCharacterInRange;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        player.characterInRange.Remove(other.gameObject);

        player.IsAttack = false;
    }

 
}
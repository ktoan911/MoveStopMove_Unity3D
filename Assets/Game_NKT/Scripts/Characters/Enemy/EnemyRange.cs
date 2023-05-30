using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Enemy enemy;

    public Collider enemyCollider;

    [SerializeField] private SphereCollider sphereCollider;

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
        if (other == enemyCollider) return;

        enemy.ResetCharInRange();

        if (other.CompareTag("Enemy"))
        {
            enemy.IsAttack = true;

            enemy.characterInRange.Add(other.gameObject);

        }

        if (other.CompareTag("Player"))
        {
            enemy.IsAttack = true;

            if (!enemy.characterInRange.Contains(other.gameObject))
            {
                enemy.characterInRange.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            enemy.characterInRange.Remove(other.gameObject);

            enemy.IsAttack = false;
        }

        //if (other.CompareTag("RangePlayer"))
        //{
        //    Player playerTmp = Cache.GetPlayerRange(other).player;

        //    enemy.RemoveCharacterInRangeAction -= playerTmp.RemoveCharacterInRange;
        //}
        //if (other.CompareTag("RangeEnemy"))
        //{
        //    Enemy enemyTmp = Cache.GetEnemyRange(other).enemy;

        //    enemy.RemoveCharacterInRangeAction -= enemyTmp.RemoveCharacterInRange;
        //}

    }
    
}

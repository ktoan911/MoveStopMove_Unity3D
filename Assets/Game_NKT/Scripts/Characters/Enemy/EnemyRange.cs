using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

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
        if (other == enemy.colliderCharacter) return;

        if (other.CompareTag("Enemy"))
        {

            Enemy enemyTmp = Cache.GetEnemyBody(other).enemy;

            enemy.IsAttack = true;

            enemy.characterInRange.Add(other.gameObject);

            enemyTmp.RemoveCharacterInRangeAction += enemy.RemoveCharacterInRange;

        }

        if (other.CompareTag("Player"))
        {
            Player playerTmp = Cache.GetPlayerBody(other).player;

            enemy.IsAttack = true;

            enemy.characterInRange.Add(other.gameObject);

            playerTmp.RemoveCharacterInRangeAction += enemy.RemoveCharacterInRange;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player playerTmp = Cache.GetPlayerBody(other).player;

            enemy.characterInRange.Remove(other.gameObject);

            enemy.IsAttack = false;

            playerTmp.RemoveCharacterInRangeAction -= enemy.RemoveCharacterInRange;
        }

        if (other.CompareTag("Enemy"))
        {
            Enemy enemyTmp = Cache.GetEnemyBody(other).enemy;

            enemy.characterInRange.Remove(other.gameObject);

            enemy.IsAttack = false;

            enemyTmp.RemoveCharacterInRangeAction -= enemy.RemoveCharacterInRange;

        }
    }
    
}

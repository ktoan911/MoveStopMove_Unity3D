using UnityEngine;

public class CharacterAttackRange : MonoBehaviour
{
    [SerializeField] private Characters character;

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

        if (other.CompareTag("Enemy"))
        {
            Enemy enemyTmp = Cache.GetEnemyBody(other).enemy;

            character.IsAttack = true;

            character.characterInRange.Add(other.gameObject);

            enemyTmp.RemoveCharacterInRangeAction += character.RemoveCharacterInRange;

        }

        if (other.CompareTag("Player"))
        {
            Player playerTmp = Cache.GetPlayerBody(other).player;

            character.IsAttack = true;

            character.characterInRange.Add(other.gameObject);

            playerTmp.RemoveCharacterInRangeAction += character.RemoveCharacterInRange;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           character.characterInRange.Remove(other.gameObject);
        }
    }
}

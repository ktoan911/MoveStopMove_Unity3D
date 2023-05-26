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

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))

        {
            enemy.IsAttack = true;

            enemy.Target = other.transform;

        }
    }
}

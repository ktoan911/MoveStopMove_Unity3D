using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    [SerializeField] private SphereCollider sphereCollider;

    public void ChangeAttackRange(float attackRange)
    {
        Vector3 Scale = Vector3.one * (attackRange / sphereCollider.radius) * 2;
        this.transform.localScale = Scale;

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

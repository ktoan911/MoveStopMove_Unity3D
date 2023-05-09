using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))

        {
            enemy.IsAttack = true;

            enemy.Target = other.transform;

        }
    }
}

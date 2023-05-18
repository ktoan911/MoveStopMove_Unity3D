using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private Player player;

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
            player.IsAttack = true;

            player.Target = other.transform;
        }
    }

 
}
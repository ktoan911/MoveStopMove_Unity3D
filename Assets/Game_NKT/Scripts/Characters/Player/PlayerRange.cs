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
        Vector3 Scale = Vector3.one * (attackRange / sphereCollider.radius) * 2;
        this.transform.localScale = Scale;

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
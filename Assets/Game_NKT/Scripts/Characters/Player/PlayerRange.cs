using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            player.IsAttack = true;

            player.Target = other.transform;

        }
    }
}
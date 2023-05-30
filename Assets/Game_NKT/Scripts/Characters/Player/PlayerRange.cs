using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public Player player;

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
        player.ResetCharInRange();

        if (other.CompareTag("Enemy"))
        {
            player.IsAttack = true;

            if (!player.characterInRange.Contains(other.gameObject))
            {
                player.characterInRange.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            player.characterInRange.Remove(other.gameObject);

            player.IsAttack = false;

        }
    }


}

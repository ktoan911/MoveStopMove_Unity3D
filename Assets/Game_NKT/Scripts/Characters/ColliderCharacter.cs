using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCharacter : MonoBehaviour
{
    [SerializeField] private GameObject character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            this.character.SetActive(false);
        }
    }
}


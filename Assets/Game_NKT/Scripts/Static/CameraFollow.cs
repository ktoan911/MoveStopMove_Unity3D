using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    private Vector3 distance;

    
    private void Start()
    {
        distance = this.transform.position - playerPosition.position;
    }

    private void LateUpdate()
    {
        this.transform.position = playerPosition.position + distance;
    }
}

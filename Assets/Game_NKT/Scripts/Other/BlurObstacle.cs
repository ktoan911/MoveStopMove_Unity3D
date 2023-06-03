using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PrefConst.OBSTACLE))
        {
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();

            obstacle.BlurObstacle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PrefConst.OBSTACLE))
        {
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();

            obstacle.ResetMatObstacle();
        }
    }
}

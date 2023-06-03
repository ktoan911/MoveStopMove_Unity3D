using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Renderer obstacleRenderer;

    [SerializeField] private Material obstacleMaterialBlur;

    [SerializeField] private Material obstacleMaterialNor;


    public void BlurObstacle()
    {
        this.obstacleRenderer.material = obstacleMaterialBlur;
    }

    public void ResetMatObstacle()
    {
        this.obstacleRenderer.material = obstacleMaterialNor;
    }
}

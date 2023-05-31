using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Renderer obstacleRenderer;

    private Material obstacleMaterial;

    private void Start()
    {
        obstacleMaterial = obstacleRenderer.material;
    }

    public void BlurObstacle()
    {
        this.obstacleMaterial.color = new Color(0, 0, 0, 20f / 255);
    }
}

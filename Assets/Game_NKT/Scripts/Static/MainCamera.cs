using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] private Transform playerPosition;

    private Vector3 distance;

    [SerializeField] private Transform shopSkinCameraPosition;

    [SerializeField] private Transform playCameraPosition;

    private void Start()
    {
        distance = this.transform.position - playerPosition.position;
    }

    private void LateUpdate()
    {
        if (GameManager.Ins.IsPlayGame)
        {
            this.transform.position = playerPosition.position + distance;
        }
    }

    public void ShopSkinCamera()
    {
        this.transform.position = this.shopSkinCameraPosition.position;

        this.transform.rotation = this.shopSkinCameraPosition.rotation;
    }

    public void PlayCamera()
    {
        this.transform.position = this.playCameraPosition.position;

        this.transform.rotation = this.playCameraPosition.rotation;
    }
}

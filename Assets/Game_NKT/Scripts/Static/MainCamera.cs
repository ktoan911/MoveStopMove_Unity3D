using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] private Transform playerPosition;

    private Vector3 distance;

    [SerializeField] private Transform shopSkinCameraPosition;

    [SerializeField] private Transform playCameraPosition;

    [SerializeField] private Transform mainMenuCameraPosition;

    private void Start()
    {
        distance = this.playCameraPosition.position - playerPosition.position;
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

    public void MainMenuCamera()
    {
        this.transform.position = this.mainMenuCameraPosition.position;

        this.transform.rotation = this.mainMenuCameraPosition.rotation;
    }
}

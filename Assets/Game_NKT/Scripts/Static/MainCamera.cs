using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera>
{
    [SerializeField] private Transform playerPosition;

    private Vector3 direction;

    [SerializeField] private Transform shopSkinCameraPosition;

    [SerializeField] private Transform playCameraPosition;

    [SerializeField] private Transform mainMenuCameraPosition;

    [SerializeField] private Player player;

    private void Start()
    {
        direction = this.playCameraPosition.position - playerPosition.position;
    }

    private void LateUpdate()
    {
        if (GameManager.Ins.IsPlayGame && player.gameObject.activeSelf)
        {
            this.transform.position = playerPosition.position + direction;
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

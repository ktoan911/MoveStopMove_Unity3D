using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject shopSkinCamera;



    public void PlayerViewInShopSkin()
    {
        shopSkinCamera.SetActive(true);

        mainCamera.SetActive(false);
    }

    public void GamePlayView()
    {
        mainCamera.SetActive(true);

        shopSkinCamera.SetActive(false);
    }

    public bool CheckActiveMainCamera()
    {
        if (mainCamera.activeSelf) return true;
        else return false;
    }


}

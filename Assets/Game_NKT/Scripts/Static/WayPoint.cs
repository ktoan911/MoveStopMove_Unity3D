using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : GameUnit
{
    public Image img;

    private Transform target;

    public Vector3 offset = new Vector3(0,20,0);

    private void Update()
    {
        if (CameraManager.Ins.CheckActiveMainCamera())
        {
            UpdatePosition();
        }
    }
    
    private void UpdatePosition()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector3 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (pos.z < 0)
        {
            pos.y = Screen.height - pos.y;
            pos.x = Screen.width - pos.x;
        }


        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public override void OnInit()
    {
        
    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new System.NotImplementedException();
    }

    public void OnInit(Characters character)
    {
        target = character.transform;

    }
}

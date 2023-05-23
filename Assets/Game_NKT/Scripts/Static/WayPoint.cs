using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : GameUnit
{
    public Image img;

    private Transform target;

    private void Update()
    {
        this.UpdatePosition();
    }
    
    private void UpdatePosition()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        //if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        //{
        //    if (pos.x < Screen.width / 2) pos.x = maxX;
        //}
        //else pos.x = minX;


        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
    }
    public override void OnDespawn()
    {
        throw new System.NotImplementedException();
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

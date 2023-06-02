using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Range,
    MoveSpeed,
    Gold
}


public class Skin : GameUnit
{
    public BuffType buffType;

    public Material pantMaterial;

    public override void OnDespawn()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInit()
    {
        throw new System.NotImplementedException();
    }

    public void OnInit(Characters t, int percentUp)
    {
        ChangepropertiesCharacter.Ins.ChangeSpeed(percentUp, t);
    }

    public override void OnInit(Characters t, float curScale)
    {
        throw new System.NotImplementedException();
    }
}

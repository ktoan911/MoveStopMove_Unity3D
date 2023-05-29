using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX : GameUnit
{
    public ParticleSystem hitVFX;

    private float curTime = 0f;

    private float timer = 1.5f;

    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime < timer) return;

        curTime = 0f;
        this.OnDespawn();

    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public override void OnInit()
    {

    }

    public void OnInit(Color color)
    {
        ParticleSystem.MainModule mainhitVFX = hitVFX.main;

        mainhitVFX.startColor = new ParticleSystem.MinMaxGradient(color);
    }


    public override void OnInit(Characters t, int percentUp)
    {
        throw new System.NotImplementedException();
    }
}

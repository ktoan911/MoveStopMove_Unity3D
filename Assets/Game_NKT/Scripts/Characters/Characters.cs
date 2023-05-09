﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Characters : GameUnit
{
    protected float speed;

    private bool isMoving;
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    private bool isAttack;
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    public Animator anim;

    protected float rotationSpeed;


    private string currentAnim;

    public Transform Target;

    private void Update()
    {
        this.CharactersUpdate();
    }

    protected virtual void CharactersUpdate()
    {
        
    }

    public Vector3 TargetDirection()
    {
        Vector3 direction = Target.position - this.transform.position;
        direction.y = 0f;
        return direction;
    }

    public void ChangeRotation()
    {     
        Quaternion rotation = Quaternion.LookRotation(TargetDirection());
        this.transform.rotation = rotation;
    }

    public override void OnInit()
    {
        IsMoving = false;
        IsAttack= false;

        speed = 7f;
        this.rotationSpeed = 100f;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }


    public override void OnDespawn()
    {
        throw new NotImplementedException();
    }
}

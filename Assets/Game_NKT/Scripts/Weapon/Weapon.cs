using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : GameUnit
{   

    [SerializeField] private float moveSpeed;

    public Vector3 direction;

    [SerializeField] private bool isFire;
    public bool IsFire { get => isFire; set => isFire = value; }

    private float timer = 1f;
    private float currentTime = 0f;

    private void Start()
    {
        moveSpeed = 1f;
    }

    private void Update()
    {
        MoveToTargetStraight();
    }

    public void SetDirection(Vector3 dir) 
    {
        direction = dir;
        IsFire = true;
    }

    public void MoveToTargetStraight()
    {
        if (IsFire)
        {
            transform.Translate(this.direction * this.moveSpeed * Time.deltaTime);
           
        }
    }  

    public override void OnDespawn()
    {
        this.IsFire = false;

        SimplePool.Despawn(this);
    }

    public override void OnInit()
    {
        this.IsFire = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.OnDespawn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Range"))
        {
            this.OnDespawn();
        }
    }
}

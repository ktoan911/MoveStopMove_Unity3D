using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Characters : GameUnit
{
    private float speed;
    public float Speed { get => speed; set => speed = value; }

    public float attackRange;

    private bool isMoving;
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    private bool isAttack;
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    public Animator anim;

    protected float rotationSpeed;


    private string currentAnim;

    public Transform Target;

    public Transform throwPoint;

    public WayPoint wayPointPrefab;

    public WayPoint waypointClone;

    public int level;

    private float scale;

    [SerializeField] private GameObject CharacterBody;



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
        return direction.normalized;
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

        Speed = 7f;
        this.rotationSpeed = 100f;
        this.attackRange = 5f;

        this.level = 1;
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

    public void SpawnWayPoint(Vector3 pos)
    {
        waypointClone = SimplePool.Spawn<WayPoint>(wayPointPrefab, pos, Quaternion.identity);
        waypointClone.OnInit(this);
        waypointClone.transform.localRotation = wayPointPrefab.transform.rotation;
    }

    public virtual void UpdateLevel(bool isUp)
    {
        if (isUp) this.level++;
        else this.level--;

        scale = 1 + level * 0.05f;

        CharacterBody.transform.localScale += new Vector3(1f, 1f, 1f) * scale;
    }
    public override void OnDespawn()
    {
        throw new NotImplementedException();
    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new NotImplementedException();
    }
}

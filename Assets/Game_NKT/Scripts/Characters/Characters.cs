using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Characters : GameUnit
{
    private float speed;

    private bool isMoving;

    private bool isAttack;

    private string currentAnim;

    private float scaleChangePercent;

    [SerializeField] private GameObject CharacterBody;

    [SerializeField] protected WayPoint wayPointPrefab;

    protected float rotationSpeed;

    public Animator anim;

    public Transform Target;

    public Transform throwPoint;

    

    public WayPoint waypointClone;

    public int level;

    public float attackRange;

    public float Speed { get => speed; set => speed = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }



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

    public virtual void SpawnWayPoint(Vector3 pos)
    {
        waypointClone = SimplePool.Spawn<WayPoint>(wayPointPrefab, pos, Quaternion.identity);
        waypointClone.OnInit(this);
        waypointClone.transform.localRotation = wayPointPrefab.transform.rotation;
    }

    public virtual void UpdateLevel(bool isUp)
    {
        if (isUp) this.level++;
        else this.level--;

        scaleChangePercent = level * 0.05f;

        CharacterBody.transform.localScale += new Vector3(1f, 1f, 1f) * scaleChangePercent;
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

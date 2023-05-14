using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters
{
    public StateMachine<Enemy> currentState;

    [SerializeField] public NavMeshAgent agent;

    public Vector3 finalPosition;

    [SerializeField] private Transform player;

    private bool isFoundCharacter;
    public bool IsFoundCharacter { get => isFoundCharacter; set => isFoundCharacter = value; }

    [SerializeField] private LayerMask layerCharacter;

    [SerializeField] private Collider enemyCollider;

    public Collider[] hitColliders;

    public int enemyIDWeapon;

    public override void OnInit()
    {
        base.OnInit();
        currentState = new StateMachine<Enemy>();
        currentState.SetOwner(this);
        IsFoundCharacter = false;

        IsAttack = false;
        currentState.ChangeState(new ESleepState());

        this.enemyIDWeapon = RandomWeapon();
    }

    protected override void CharactersUpdate()
    {
        currentState.UpdateState(this);

        base.CharactersUpdate();
    }

    public void SeekForTarget() 
    {
        Vector3 scaleBox = new Vector3(100, 5, 100);
        hitColliders = Physics.OverlapBox(this.transform.position, scaleBox / 2, Quaternion.identity, layerCharacter);

        if(hitColliders.Length <2)
        {
            finalPosition = player.position; // ko the keo tha transform player ???

            return;
        }

        float minDistance = float.MaxValue;
        Vector3 minPos = Vector3.zero;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i] == this.enemyCollider)
            {
                continue;
            }

            float distanceTmp = Vector3.Distance(hitColliders[i].transform.position, this.transform.position);

            if (distanceTmp < minDistance)
            {
                minDistance = distanceTmp;
                minPos = hitColliders[i].transform.position;
            }
        }

        finalPosition = minPos;
        IsFoundCharacter = true;
        GotoTarget();
    }

    
    public void GotoTarget()
    {
        agent.SetDestination(finalPosition);

    }

    public void StopMove()
    {
        this.finalPosition = this.transform.position;
        this.GotoTarget();
    }

    public bool IsGotoTarget()
    {
        if(Vector3.Distance(this.transform.position, finalPosition) < 2.5f)
        {
            IsFoundCharacter = false;

            return true;
        }
        return false;
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    private int RandomWeapon()
    {
        int TmpRandom = Random.Range(1, SOManager.Ins.weaponS0.Count + 1);

        for (int i = 0; i < SOManager.Ins.weaponS0.Count; i++)
        {
            if (SOManager.Ins.weaponS0[i].IDWeapon == TmpRandom) return SOManager.Ins.weaponS0[i].IDWeapon;
        }
        return SOManager.Ins.weaponS0[0].IDWeapon;

    }
}

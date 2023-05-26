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

    public EnemyRange enemyAttackRange;

    public int enemyIDWeapon;

    public bool isIntialActive = false;

    public SkinnedMeshRenderer mat;

    [SerializeField] private ColorData colordata;

    public override void OnInit()
    {
        base.OnInit();
        currentState = new StateMachine<Enemy>();
        currentState.SetOwner(this);
        IsFoundCharacter = false;

        IsAttack = false;
        currentState.ChangeState(new ESleepState());

        this.enemyIDWeapon = RandomWeapon();

        this.RandomMaterial();
    }

    protected override void CharactersUpdate()
    {
        currentState.UpdateState(this);

        base.CharactersUpdate();
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }

    public void SeekForTarget() 
    {

        #region seek enemy
        //Vector3 scaleBox = new Vector3(100, 5, 100);
        //hitColliders = Physics.OverlapBox(this.transform.position, scaleBox / 2, Quaternion.identity, layerCharacter);

        //if(hitColliders.Length <2)
        //{
        //    finalPosition = player.position; // ko the keo tha transform player ???

        //    return;
        //}

        //float minDistance = float.MaxValue;
        //Vector3 minPos = Vector3.zero;

        //for (int i = 0; i < hitColliders.Length; i++)
        //{
        //    if (hitColliders[i] == this.enemyCollider)
        //    {
        //        continue;
        //    }

        //    float distanceTmp = Vector3.Distance(hitColliders[i].transform.position, this.transform.position);

        //    if (distanceTmp < minDistance)
        //    {
        //        minDistance = distanceTmp;
        //        minPos = hitColliders[i].transform.position;
        //    }
        //}

        #endregion

        finalPosition = GetRandomPoint(new Vector3(0, 0, 0), 50f) ;

        IsFoundCharacter = true;
        GotoTarget();
    }

    
    public void GotoTarget()
    {
        agent.SetDestination(finalPosition);
    }

    public void GotoPoint(Vector3 pos)
    {
        agent.SetDestination(pos);
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
            if (SOManager.Ins.weaponS0[i].ID == TmpRandom) return SOManager.Ins.weaponS0[i].ID;
        }
        return SOManager.Ins.weaponS0[0].ID;

    }

    private void RandomMaterial()
    {
        int random = Random.Range(0, colordata.matsList.Count);

        this.mat.material = colordata.matsList[random];
    }

    public override void UpdateLevel(bool isUp)
    {
        base.UpdateLevel(isUp);

        EquipManager.Ins.ChangeEnemyAttackRange(10, this);
    }
}

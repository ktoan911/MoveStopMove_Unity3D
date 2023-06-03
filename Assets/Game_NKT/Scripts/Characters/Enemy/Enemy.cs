using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters
{
    private bool isFoundCharacter;

    [SerializeField] public NavMeshAgent agent;

    [SerializeField] private Transform player;

    public StateMachine<Enemy> currentState;

    public Vector3 finalPosition;

    public int enemyIDWeapon;

    public bool isIntialActive = false;

    [SerializeField] private ColorData colordata;
    public bool IsFoundCharacter { get => isFoundCharacter; set => isFoundCharacter = value; }


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
        finalPosition = GetRandomPoint(new Vector3(0, 0, 0), 50f) ;

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
        base.OnDespawn();

        this.currentState.ChangeState(new EDeadState());
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

        this.materialCharacter.material = colordata.matsList[random];
    }

    public void RandomName(List<string> listName)
    {
        int nameRandomNumber = Random.Range(0, listName.Count);

        this.characterName = listName[nameRandomNumber];
        listName.Remove(this.characterName);


    }

    public override void UpdateLevel(bool isUp)
    {
        base.UpdateLevel(isUp);

        ChangepropertiesCharacter.Ins.ChangeEnemyAttackRange(this.currentScale, this);
    }

}

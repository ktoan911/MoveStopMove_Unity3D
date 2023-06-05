using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters
{
    private bool isFoundCharacter;

    [SerializeField] public NavMeshAgent agent;

    public StateMachine<Enemy> currentState;

    public Vector3 finalPosition;

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

        this.SetIntialEquip();
    }

    protected override void CharactersUpdate()
    {
        currentState.UpdateState(this);

        base.CharactersUpdate();
    }

    private void SetIntialEquip()
    {
        this.weaponID = RandomWeapon();

        this.skinPantID = RandomPant();

        this.skinHairID = RandomHair();

        ChangeSkin.Ins.ChangeModelHair(this.hair, this.skinHairID);

        ChangeSkin.Ins.ChangePant(this, this.pants, this.skinHairID);

        WeaponSpawner.Instance.ChangeModelWeaponEnemy(this, this.rightHand, this.weaponID);

        this.RandomMaterial();
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
        int TmpRandom = Random.Range(0, SOManager.Ins.weaponS0.Count);

        for (int i = 0; i < SOManager.Ins.weaponS0.Count; i++)
        {
            if (SOManager.Ins.weaponS0[i].ID == TmpRandom) return SOManager.Ins.weaponS0[i].ID;
        }
        return SOManager.Ins.weaponS0[0].ID;

    }

    private int RandomHair()
    {
        int TmpRandom = Random.Range(0, SOManager.Ins.skinHairS0.Count);

        for (int i = 0; i < SOManager.Ins.skinHairS0.Count; i++)
        {
            if (SOManager.Ins.skinHairS0[i].ID == TmpRandom) return SOManager.Ins.skinHairS0[i].ID;
        }
        return SOManager.Ins.skinHairS0[0].ID;
    }

    private int RandomPant()
    {
        int TmpRandom = Random.Range(0, SOManager.Ins.skinPantsS0.Count);

        for (int i = 0; i < SOManager.Ins.skinPantsS0.Count; i++)
        {
            if (SOManager.Ins.skinPantsS0[i].ID == TmpRandom) return SOManager.Ins.skinPantsS0[i].ID;
        }
        return SOManager.Ins.skinPantsS0[0].ID;
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

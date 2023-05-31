using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class Characters : GameUnit
{
    private float speed;

    private bool isMoving;

    private bool isAttack;

    private string currentAnim;

    private float currentScale;

    private bool isUpScaleWeapon;

    [SerializeField] private GameObject CharacterBody;

    [SerializeField] protected WayPoint wayPointPrefab;

    [SerializeField] private LevelChangeData levelChangeData;

    protected float rotationSpeed;

    public Animator anim;

    public Transform throwPoint;

    public string characterName;

    public WayPoint waypointClone;

    public int level;

    public float attackRange;

    public SkinnedMeshRenderer materialCharacter;

    public Characters characterKill;

    public List<Transform> characterInRange = new List<Transform>();

    public Collider colliderCharacter;

    public HitVFX hitVFX;

    public UnityAction<GameObject> RemoveCharacterAction;


    public float Speed { get => speed; set => speed = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public bool IsUpScaleWeapon { get => isUpScaleWeapon; set => isUpScaleWeapon = value; }

    private void Update()
    {
        this.CharactersUpdate();
    }

    protected virtual void CharactersUpdate()
    {
        
    }

    public Vector3 TargetDirection()
    {
        if(characterInRange.Count <= 0) return Vector3.zero;
        //TODO: cache transform
        Vector3 direction = this.characterInRange[0].position - this.transform.position;
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

        this.currentScale = 1f;

        this.IsUpScaleWeapon = false;
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

        currentScale = levelChangeData.GetScale(level, currentScale);

        CharacterBody.transform.localScale = Vector3.one * currentScale;
    }

    public void SpawnVFX()
    {
        HitVFX hit = SimplePool.Spawn<HitVFX>(this.hitVFX, this.transform.position + Vector3.up, Quaternion.identity);
        hit.OnInit(materialCharacter.material.color);
    }

    public bool CheckAllIsAround()
    {
        this.characterInRange.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        for (int i = 0; i < hitColliders.Length; i++)
        {

            //TODO: cache string
            if ((hitColliders[i].CompareTag("Player") || hitColliders[i].CompareTag("Enemy")) && hitColliders[i] != this.colliderCharacter)
            {
                if (!this.characterInRange.Contains(hitColliders[i].transform))
                {
                    this.characterInRange.Add(hitColliders[i].transform);
                }

                return true;
            }
        }
        return false;

    }
    public override void OnDespawn()
    {

    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new NotImplementedException();
    }

    public virtual void OnHit(Characters character)
    {
        this.characterKill= character;

        this.OnDespawn();
    }

    public virtual void UpCoin(Characters character)
    {
        if (character == null) return;
    }
}

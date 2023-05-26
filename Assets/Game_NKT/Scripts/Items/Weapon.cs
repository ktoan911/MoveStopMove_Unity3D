using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class Weapon : GameUnit
{   

    [SerializeField] private float moveSpeed;

    public Vector3 direction;

    [SerializeField] private bool isFire;
    public bool IsFire { get => isFire; set => isFire = value; }

    private float timeSelfDestroy;

    private Characters characterAttack;

    private void Update()
    {
        SelfDestroy();

        MoveToTargetStraight();
    }

    public void SetDataWeapon(Vector3 dir, Characters character) 
    {
        this.characterAttack = character;

        direction = dir;
        IsFire = true;


    }

    public void MoveToTargetStraight()
    {
        if (IsFire)
        {
            transform.Translate(this.direction.normalized * this.moveSpeed * Time.deltaTime, Space.World);
           
        }
    }  

    public override void OnDespawn()
    {
        this.IsFire = false;

        SimplePool.Despawn(this);
    }

    public void SetTimeDestroy(float attackRange)
    {
        this.timeSelfDestroy = attackRange / moveSpeed;
    }

    public override void OnInit()
    {
        this.IsFire = false;

        moveSpeed = 4.5f;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            this.OnDespawn();

            UpdateLevelCharacter(characterAttack);
        }
    }

    private void SelfDestroy()
    {
        timeSelfDestroy -= Time.deltaTime;
        if (timeSelfDestroy > 0) return;

        this.OnDespawn();
    }

    private void UpdateLevelCharacter(Characters character)
    {
        character.UpdateLevel(true);
    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new System.NotImplementedException();
    }
}

using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class Weapon : GameUnit
{
    private float timeSelfDestroy;

    private bool isFire;

    private Characters characterAttack;

    private bool isUpScaleDeltatime;

    private Vector3 lastScale;

    private bool isRotate;

    [SerializeField] private float moveSpeed;

    public Vector3 direction;
    public bool IsFire { get => isFire; set => isFire = value; }


    private void Update()
    {
        SelfDestroy();

        MoveToTargetStraight();

        //RotateWeapon();
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
            if(isUpScaleDeltatime)
            {
                this.transform.localScale += Vector3.one * 0.15f;
            }

            if(isRotate) RotateWeapon();

            transform.Translate(this.direction.normalized * this.moveSpeed * Time.deltaTime, Space.World);
           
        }
    }  

    public override void OnDespawn()
    {
        this.IsFire = false;

        this.isUpScaleDeltatime = false;

        this.transform.localScale = lastScale;


        SimplePool.Despawn(this);
    }

    public void SetTimeDestroy(float attackRange)
    {
        this.timeSelfDestroy = attackRange  / moveSpeed;
    }

    public override void OnInit()
    {
        
    }

    public void OnInit(bool isRotate)
    {
        this.IsFire = false;

        this.lastScale = this.transform.localScale;

        this.isRotate = isRotate;

        moveSpeed = 10f;
    }
    private void SelfDestroy()
    {
        timeSelfDestroy -= Time.deltaTime;
        if (timeSelfDestroy > 0) return;

        this.OnDespawn();
    }

    public void UpScaleWeapon()
    {
        this.isUpScaleDeltatime = true;

        this.isRotate = false;
    }

    private void RotateWeapon()
    {
        transform.Rotate(0, 400 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PrefConst.ENEMY))
        {
            Enemy e = Cache.GetEnemyBody(other).enemy;

            if (e != null && e != this.characterAttack)
            {
                this.characterAttack.UpdateLevel(true);

                this.characterAttack.UpCoin(e);

                e.OnHit(this.characterAttack);

            }

            this.OnDespawn();
        }

        if (other.CompareTag(PrefConst.PLAYER))
        {
            Player p = Cache.GetPlayerBody(other).player;

            if (p != null && p != this.characterAttack)
            {
                this.characterAttack.UpdateLevel(true);

                this.characterAttack.UpCoin(p);

                p.OnHit(this.characterAttack);

            }

            this.OnDespawn();
        }
    }
}

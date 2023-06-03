using UnityEngine;
using UnityEngine.Events;


public class Gift : GameUnit
{

    private int randomNum;

    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        transform.Rotate(0, 80 * Time.deltaTime, 0);
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public override void OnInit()
    {
        randomNum = Random.Range(0, 2);
    }

    public override void OnInit(Characters t, float curScale)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PrefConst.GROUND))
        {
            Vector3 giftPos = this.transform.position;

            rb.isKinematic= true;

            this.transform.position= giftPos;
        }

        if (other.CompareTag(PrefConst.PLAYER))
        {
            Player player = Cache.GetPlayerBody(other).player;

            this.BuffPlayer(player);

            this.OnDespawn();
        }

        if (other.CompareTag(PrefConst.ENEMY))
        {
            Enemy enemy = Cache.GetEnemyBody(other).enemy;

            this.BuffEnemy(enemy);

            this.OnDespawn();
        }
    }

    private void BuffPlayer(Player player)
    {
        ChangepropertiesCharacter.Ins.ChangePlayerAttackRangeGift(20, player);

        player.UpScaleCharacter(2);

        player.IsUpScaleWeapon = true;
    }

    private void BuffEnemy(Enemy enemy)
    {
        ChangepropertiesCharacter.Ins.ChangeEnemyAttackRangeGift(20, enemy);

        enemy.UpScaleCharacter(2);

        enemy.IsUpScaleWeapon = true;
    }
}

using UnityEngine;
using UnityEngine.Events;

public enum TypeBuffGift { UpRange, UpScaleWeapon }

public class Gift : GameUnit
{

    private TypeBuffGift typeBuffGift;

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

        typeBuffGift = (TypeBuffGift)randomNum;
    }

    public override void OnInit(Characters t, int percentUp)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Vector3 giftPos = this.transform.position;

            rb.isKinematic= true;

            this.transform.position= giftPos;
        }

        if (other.CompareTag("Player"))
        {
            Player player = Cache.GetPlayerBody(other).player;

            this.BuffPlayer(player);

            this.OnDespawn();
        }

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = Cache.GetEnemyBody(other).enemy;

            this.BuffEnemy(enemy);

            this.OnDespawn();
        }
    }

    private void BuffPlayer(Player player)
    {
        switch (typeBuffGift)
        {
            case TypeBuffGift.UpRange:
                ChangepropertiesCharacter.Ins.ChangePlayerAttackRange(Random.Range(1, 15),player);
                break;
            case TypeBuffGift.UpScaleWeapon:
                player.IsUpScaleWeapon= true;
                break;

        }
    }

    private void BuffEnemy(Enemy enemy)
    {
        switch (typeBuffGift)
        {
            case TypeBuffGift.UpRange:
                ChangepropertiesCharacter.Ins.ChangeEnemyAttackRange(Random.Range(1, 15), enemy);
                break;
            case TypeBuffGift.UpScaleWeapon:
                enemy.IsUpScaleWeapon = true;
                break;

        }
    }
}

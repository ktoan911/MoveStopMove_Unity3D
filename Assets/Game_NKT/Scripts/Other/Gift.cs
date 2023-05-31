using UnityEngine;
using UnityEngine.Events;

public enum TypeBuffGift { UpRange, UpScaleWeapon }

public class Gift : GameUnit
{

    private TypeBuffGift typeBuffGift;

    private int randomNum;

    [SerializeField] private Rigidbody rb;

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
            rb.isKinematic= true;
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

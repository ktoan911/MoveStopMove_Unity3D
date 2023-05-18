using UnityEngine;

public class Player : Characters
{
    [SerializeField] private FloatingJoystick joystick;

    [SerializeField] private CharacterController characterController;

    public StateMachine<Player> currentState;

    public int weaponID;

    private int skinHairID;

    private int skinShieldID;

    private int skinPantID;

    [SerializeField] private Transform rightHand;

    [SerializeField] private SkinnedMeshRenderer pants;

    [SerializeField] private Transform hair;

    [SerializeField] private Transform leftHand;

    [SerializeField] private PlayerRange playerRange;

    public CircleAroundPlayer range;


    private int coins;
    public int Coins { get => coins; set => coins = value; }

    private float gravity;

    private float horizontal;
    private float vertical;


    private void Start()
    {
        this.OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();

        this.SetInitalEquip();
        currentState = new StateMachine<Player>();
        currentState.SetOwner(this);
        this.gravity = 20f;
        currentState.ChangeState(new IdleState());
    }

    private void SetInitalEquip()
    {
        this.ChangeWeapon(Pref.CurWeaponId);

        this.ChangePant(Pref.CurPantId);

        this.ChangeShield(Pref.CurShieldId);  

        this.ChangeHair(Pref.CurHairId);
    }

    //====Update======

    protected override void CharactersUpdate()
    {
        currentState.UpdateState(this);

        SetGravity();

        base.CharactersUpdate();

        IsMove();
    }

    //====Setup Joystick =======

    public void SetupJoystick(FloatingJoystick joystick)
    {
        this.joystick = joystick;
    }


    //=====SetGravity======
    private void SetGravity()
    {
        characterController.Move(Vector3.down * gravity * Time.deltaTime);
    }

    //===PlayerMovement=====

    private void GetInput()
    {
        if (joystick == null) return;
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
    }
    public bool IsMove()
    {
        GetInput();

        if (Mathf.Abs(this.horizontal) > 0.1f || Mathf.Abs(this.vertical) > 0.1f)
        {
            this.IsMoving= true;

            return true;
        }
        return false;
    }
    public void Moving()
    {
        GetInput();

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            characterController.Move(direction * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void UpdateCoin(int coinChange, bool isUp)
    {
        if (isUp) this.Coins += coinChange;
        else this.Coins -= coinChange;
        Pref.Coins = this.Coins;
    }

    public void ChangeWeapon(int id)
    {
        this.weaponID= id;
        Debug.Log(this.weaponID);

        WeaponSpawner.Instance.ChangeModelWeaponPlayer(rightHand, id);
    }

    public void ChangePant(int id)
    {
        this.skinPantID = id;

        ChangeSkinPlayer.Ins.ChangePant(pants, skinPantID);
    }

    public void ChangeHair(int id)
    {

        this.skinHairID = id;

        ChangeSkinPlayer.Ins.ChangeModelHair(hair, skinHairID);
    }

    public void ChangeShield(int id)
    {
        this.skinShieldID = id;

        ChangeSkinPlayer.Ins.ChangeModelShield(leftHand, skinShieldID);
    }
    
    public void ChangeAttackRange(float percentChange)
    {
        playerRange.ChangeAttackRange(this.attackRange * (1 + percentChange / 100));

        range.ChangeAttackRangeCircle(this.attackRange * (1 + percentChange / 100));
    }

    public void ChangeSpeed(float percentChange)
    {
        this.speed = this.speed * (1 + percentChange / 100);
    }





}

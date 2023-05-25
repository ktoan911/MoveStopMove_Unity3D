using UnityEngine;
using UnityEngine.Events;

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

    public PlayerRange playerRange;

    public CircleAroundPlayer range;

    public UnityAction DeadUI;


    private int coins;
    public int Coins { get => coins; set => coins = value; }

    private float gravity;

    private float horizontal;
    private float vertical;

    private void Awake()
    {
        this.OnInit();
    }
    private void Start()
    {
        currentState = new StateMachine<Player>();
        currentState.SetOwner(this);

        currentState.ChangeState(new SleepState());
    }

    public override void OnInit()
    {
        base.OnInit();

        this.gravity = 20f;

    }

    public void SetInitalEquip()
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
            characterController.Move(direction * Speed * Time.deltaTime);
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

        WeaponSpawner.Instance.ChangeModelWeaponPlayer(this,rightHand, id);
    }

    public void ChangePant(int id)
    {
        this.skinPantID = id;

        ChangeSkin.Ins.ChangePant(this, pants, skinPantID);
    }

    public void ChangeHair(int id)
    {

        this.skinHairID = id;

        ChangeSkin.Ins.ChangeModelHair(hair, skinHairID);
    }

    public void ChangeShield(int id)
    {
        this.skinShieldID = id;

        ChangeSkin.Ins.ChangeModelShield(leftHand, skinShieldID);
    }

}

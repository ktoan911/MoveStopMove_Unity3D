using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Characters
{
    [SerializeField] private FloatingJoystick joystick;

    [SerializeField] private CharacterController characterController;

    public StateMachine<Player> currentState;

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
        currentState = new StateMachine<Player>();
        currentState.SetOwner(this);
        this.gravity = 20f;
        currentState.ChangeState(new IdleState());
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


    


}

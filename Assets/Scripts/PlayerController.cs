using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//everytime i add a player controller , a rb has to exist:
[RequireComponent(typeof (Rigidbody2D), typeof(TouchingDirections))] // u cant add a player controller to a game object unless a rigid body already exists
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpImpulse = 10f;

    Vector2 moveInput;
    TouchingDirections touchingDirections;
    
    //setting the current velocity of the player w/ CurrentMoveSpeed
    public float CurrentMoveSpeed { get
        {
            if(IsMoving)
            {
                return walkSpeed;
            } else
            {
                //idle speed is 0
                return 0;
            }
        } }

    [SerializeField]
    private bool _IsMoving = false; //stin arxi den kounietai
    public bool IsMoving { get 
        {
            return _IsMoving;
        } 
        private set {
            _IsMoving = value;
            animator.SetBool(AnimationStrings.IsMoving, value);
        } 
    }

    public bool _IsFacingRight = true;
    public bool IsFacingRight { get { return _IsFacingRight; } private set {
            if (_IsFacingRight != value)
            {
                //flip the local scale to make the player facing opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }

                _IsFacingRight = value;

        } }

    Rigidbody2D rb;
    Animator animator; 

    //methodos awake, to start erxetai meta apo to awake, (using it to find sth as soon as possible)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //physics update, rigid vody --> fixedupdate
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed , rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            //face the right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //face the left
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // parametros oti o paixtis mporei na pidiksei otan tha akoympaei sto ground
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);

        }
    }

    //Attack triggers :
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attack);
        }
    }

    public void OnSkill2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.skill2);
        }
    }

    public void OnSkill3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.skill3);
        }
    }
    public void PlayerIsDying()
    {
            Debug.Log("pethainw");
            animator.SetTrigger(AnimationStrings.PlayerIsDying);
   
    }

}

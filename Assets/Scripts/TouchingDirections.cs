using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Orismos twn Ground-Air States , 
public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    Rigidbody2D rb;
    CapsuleCollider2D touchingCollider;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];

    [SerializeField]
    private bool _IsGrounded;
    public bool IsGrounded { get
        {
            return _IsGrounded;
        }
        private set {
            _IsGrounded = value;
            animator.SetBool(AnimationStrings.IsGrounded, value);
        }
    }

    [SerializeField] 
    private bool _IsOnWall;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
    public bool IsOnWall
    {
        get
        {
            return _IsOnWall;
        }
        private set
        {
            _IsOnWall = value;
            animator.SetBool(AnimationStrings.IsOnWall, value);
        }
    }
    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
    }
}

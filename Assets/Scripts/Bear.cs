using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Bear : MonoBehaviour
{
    public float speed = 25f;
    private Rigidbody2D rb;
    public Sleep bearMovement;
    public EnemyHealth enemyhealth;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bearMovement.IsMoving=true;
    }

    void FixedUpdate()
    {
        if (bearMovement.IsMoving)
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsAsleep", false);
        }
        else
        {
            if (enemyhealth.Ehealth > 0)
            {
                animator.SetBool("IsAsleep", true);
                animator.SetBool("IsMoving", false);
            }
            else
            {
                transform.Translate(0 * Time.fixedDeltaTime, 0, 0);
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D objects)
    {
        if (objects.gameObject.tag == "rocks" || objects.gameObject.tag == "Player" || objects.gameObject.tag == "spathi" )
        {
            transform.Rotate(0f, 180f, 0f);
            Debug.Log("geiaaa!!!");
        }

    }
    public void Hurt()
    {
        animator.SetTrigger("IsHurt");
    }
    public void Die()
    {
        animator.SetTrigger("IsDying");
    }

}



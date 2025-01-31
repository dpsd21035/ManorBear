using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{

    public bool IsMoving = true;
    Animator animator;
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy" && Input.GetKey("z"))
        {
            StopMovementForSeconds(5);
            Debug.Log("zzz");
        }

       
    }

    public void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "enemy" && Input.GetKeyDown("z"))
        {
            StopMovementForSeconds(5);
            Debug.Log("zzz");
        }
    }


    public void StopMovementForSeconds(float delay)
    {
        StartCoroutine(StopMovementCoroutine(delay));
    }

    private IEnumerator StopMovementCoroutine(float delay)
    {
        yield return new WaitForSeconds(1);
        IsMoving = false; // Stop the movement
        yield return new WaitForSeconds(delay); 
        IsMoving = true; // Resume movement after the delay
    }

}

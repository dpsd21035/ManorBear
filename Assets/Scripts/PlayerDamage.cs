using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDamage : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy" && Input.GetKeyDown("space"))
        {
            Debug.Log("ouch me xtipises 1");
            enemyHealth.ETakeDamage(1);
        }
        else if (collider.gameObject.tag == "enemy" && Input.GetKeyDown("x"))
                    {
            Debug.Log("ouch me xtipises 3");
            enemyHealth.ETakeDamage(3);
        }

    }


}
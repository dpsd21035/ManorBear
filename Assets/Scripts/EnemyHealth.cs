using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int Ehealth;
    public int EmaxHealth = 50;
    Animation animator;
    public Bear bear;
    public Sleep bearMovement;
    float delay = 2f;
    void Start()
    {
        Ehealth = EmaxHealth;
    }

    public void ETakeDamage(int amount)
    {
        Ehealth -= amount;
        bear.Hurt();
        if (Ehealth <= 0)
        {
            bear.Die();
            bearMovement.IsMoving = false;
            Invoke(nameof(GameWon), delay);
        }
    }

    public void GameWon()
    {
        SceneManager.LoadSceneAsync(3);
    }

}

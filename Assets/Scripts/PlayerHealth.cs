using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour 
    {
    public int health;
    public int maxHealth = 3;
    float delay = 2f;
    public PlayerController player;



    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <=0)
        {
            player.PlayerIsDying();
            Invoke(nameof(GameLost), delay);
        }
    }
    public void GameLost()
    {
        SceneManager.LoadSceneAsync(2);
    }

}


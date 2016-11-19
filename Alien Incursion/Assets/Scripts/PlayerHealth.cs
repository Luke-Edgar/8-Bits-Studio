﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100f;
    //maxArmour can be increased with armour upgrade
    public float maxArmour = 25f;

    public float currentHealth;
    public float currentArmour;
    public float startArmour = 25f;
	public bool playerAlive = true;
    public int playerLives = 5;

	public GameUI game;
	public LevelManager manager;

	// Use this for initialization
	void Start () {
        game = FindObjectOfType<GameUI>();
        manager = FindObjectOfType<LevelManager>();

        currentHealth = maxHealth;
		currentArmour = startArmour;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void HurtPlayer(float amount)
    {
        float hurtArmour;
        float hurtLife;

        hurtArmour = amount * 0.80f;
        hurtLife = amount * 0.20f;

		if (currentArmour > 0)
        {
			currentArmour -= hurtArmour;
			if (currentArmour < 0)
            {
				hurtArmour = Math.Abs(currentArmour);
				currentArmour = 0;
            }
            else
            {
                hurtArmour = 0;
            }
        }

        currentHealth -= (hurtLife + hurtArmour);


        if (currentHealth <= 0)
        {
            KillPlayer();
        }

        game.UpdateGameUI();
        //Debug.Log("Player Taking Damage");

    }

    public void KillPlayer()
    {
        playerAlive = false;
        playerLives -= 1;
        if (playerLives < 0)
        {
            game.EndGame();
        }
        else
        {
            manager.Respawn();
            game.UpdateGameUI();
        }

	}

	public void Spawn()
    {
		currentHealth = maxHealth;
		currentArmour = maxArmour;
        playerAlive = true;
    }

    public void TestHurt()
    {
        HurtPlayer(10);

	}

	public void AddHealth (float healthAmount)
	{
    	currentHealth += healthAmount;
    	if (currentHealth > maxHealth) currentHealth = maxHealth;
	}

	public void AddArmour (float armourAmount)
	{
    	currentArmour += armourAmount;
    	if (currentArmour > maxArmour) currentArmour = maxArmour;
	}

	public void IncreaseMaxArmour (float increaseMaxArmour)
	{
    	maxArmour += increaseMaxArmour;
    	currentArmour = maxArmour;
	}
}

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth = 100f;
	public float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HurtEnemy(float damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

	public void KillEnemy()
    {
        Destroy(gameObject);
	}
}

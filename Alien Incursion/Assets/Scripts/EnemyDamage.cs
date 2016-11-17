using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public PlayerHealth playerHealth;

	public float damage = 10f;
    public float hitRate = 0.5f;
    float nextHit = 0f;

	// Use this for initialization
	void Awake () {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerHealth.HurtPlayer(damage);
			nextHit = Time.time + hitRate;
        }
    }

    void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			if (Time.time > nextHit) {
				nextHit = Time.time + hitRate;
				playerHealth.HurtPlayer(damage);
			}
		}
	}

}

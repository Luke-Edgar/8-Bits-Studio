using UnityEngine;
using System.Collections;

public class BossDamage : MonoBehaviour {

	public PlayerHealth playerHealth;

	EnemyProjectileController thisPC;

	public float damage = 10f;

	// Use this for initialization
	void Awake () {
        playerHealth = FindObjectOfType<PlayerHealth>();
        thisPC = GetComponentInParent<EnemyProjectileController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Player") {
			PlayerHealth hurtPlayer = coll.gameObject.GetComponent<PlayerHealth>();
			thisPC.RemoveForce ();
			hurtPlayer.HurtPlayer(damage);
			Destroy(transform.root.gameObject);
        }
    }
}

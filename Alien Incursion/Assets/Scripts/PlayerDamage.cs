using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

	public EnemyHealth enemyHealth;

	ProjectileController thisPC;

	public float damage = 10f;

	// Use this for initialization
	void Awake () {
        enemyHealth = FindObjectOfType<EnemyHealth>();
        thisPC = GetComponentInParent<ProjectileController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Shield") {
			thisPC.RemoveForce ();
			Destroy (transform.root.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Enemy") {
			EnemyHealth hurtEnemy = coll.gameObject.GetComponent<EnemyHealth>();
			thisPC.RemoveForce ();
			hurtEnemy.HurtEnemy(damage);
			Destroy(transform.root.gameObject);
        }
    }
}

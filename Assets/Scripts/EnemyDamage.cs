using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public PlayerHealth playerHealth;

	public float damage = 10f;

	// Use this for initialization
	void Start () {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
        	Debug.Log ("Player Damage");
            playerHealth.HurtPlayer(damage);
        }
    }

}

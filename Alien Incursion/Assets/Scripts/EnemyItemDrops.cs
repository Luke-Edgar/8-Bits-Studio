using UnityEngine;
using System.Collections;

public class EnemyItemDrops : MonoBehaviour {

	GameObject healthPickup;
	public EnemyHealth enemyHealth;

	// Use this for initialization
	public void Awake () {
		healthPickup = Resources.Load("HealthPickup", typeof(GameObject)) as GameObject;
		enemyHealth = FindObjectOfType<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DropItem() {
		Instantiate(healthPickup, enemyHealth.transform.position, enemyHealth.transform.rotation);
	}
}

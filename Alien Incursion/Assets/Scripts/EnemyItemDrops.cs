using UnityEngine;
using System.Collections;

public class EnemyItemDrops : MonoBehaviour {

	public GameObject healthPickup;
	public EnemyHealth enemyHealth;

	// Use this for initialization
	public void Awake () {
		healthPickup = Resources.Load("HealthPickup", typeof(GameObject)) as GameObject;
        enemyHealth = (EnemyHealth)this.gameObject.GetComponent<EnemyHealth>();

    }
	
	// Update is called once per frame
	void Update () {

	}

	public void DropItem() {
		Instantiate(healthPickup, enemyHealth.transform.position, enemyHealth.transform.rotation);        
    }
}

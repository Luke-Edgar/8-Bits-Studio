using UnityEngine;
using System.Collections;

public class EnemyItemDrops : MonoBehaviour {

	public GameObject healthPickup;
	public GameObject armourPickup;
	public GameObject ammoPickup;
	public EnemyHealth enemyHealth;

	// Use this for initialization
	public void Awake () {
		healthPickup = Resources.Load("HealthPickup", typeof(GameObject)) as GameObject;
		armourPickup = Resources.Load("ArmourPickup", typeof(GameObject)) as GameObject;
		ammoPickup = Resources.Load("AmmoPickup", typeof(GameObject)) as GameObject;
        enemyHealth = (EnemyHealth)this.gameObject.GetComponent<EnemyHealth>();
    }
	
	// Update is called once per frame
	void Update () {

	}

	public void DropItem ()
	{
		int item = Random.Range (0, 4);
		//Debug.Log(item);
		if (item == 0) {
			return;
		} else if (item == 1) {
			Instantiate(healthPickup, enemyHealth.transform.position, enemyHealth.transform.rotation);
		} else if (item == 2) {
			Instantiate(armourPickup, enemyHealth.transform.position, enemyHealth.transform.rotation);
		} else if (item == 3) {
			Instantiate(ammoPickup, enemyHealth.transform.position, enemyHealth.transform.rotation);
		}
		//        
    }
}

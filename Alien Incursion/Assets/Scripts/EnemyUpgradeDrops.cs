using UnityEngine;
using System.Collections;

public class EnemyUpgradeDrops : MonoBehaviour {

	public GameObject armourUpgradePickup;
	public GameObject doubleJumpUpgrade;
	public EnemyHealth enemyHealth;

	// Use this for initialization
	void Awake () {
		armourUpgradePickup = Resources.Load("ArmourUpgrade", typeof(GameObject)) as GameObject;
		doubleJumpUpgrade = Resources.Load("DoubleJumpUpgrade", typeof(GameObject)) as GameObject;
        enemyHealth = (EnemyHealth)this.gameObject.GetComponent<EnemyHealth>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropDoubleJump ()
	{
		Instantiate(doubleJumpUpgrade, enemyHealth.transform.position, enemyHealth.transform.rotation);
	}

	public void DropArmourUpgrade ()
	{
		Instantiate(armourUpgradePickup, enemyHealth.transform.position, enemyHealth.transform.rotation);
	}
}

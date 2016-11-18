using UnityEngine;
using System.Collections;

public class EnemyUpgradeDrops : MonoBehaviour {

	

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropDoubleJump ()
	{
		Debug.Log("Double Jump Dropped");
	}

	public void ArmourUpgradeDrop ()
	{
		Debug.Log("Armour Upgrade Dropped");
	}
}

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth = 100f;
	public float currentHealth;

	public EnemyItemDrops itemDrop;
	public EnemyUpgradeDrops upgradeDrop;
	public bool itemDrops = true;
	public bool doubleJumpDrop = false;
	public bool armorUpgradeDrop = false;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
		itemDrop = FindObjectOfType<EnemyItemDrops>();
		upgradeDrop = FindObjectOfType<EnemyUpgradeDrops>();
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

	public void KillEnemy ()
	{
		if (itemDrops) {
			itemDrop.DropItem ();
		} else if (doubleJumpDrop) {
			upgradeDrop.DropDoubleJump ();
		} else if (armorUpgradeDrop) {
			upgradeDrop.ArmourUpgradeDrop ();
		} else {
			return;
		}

		Destroy (this.gameObject);
        	
	}
}

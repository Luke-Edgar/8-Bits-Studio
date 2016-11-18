using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth = 100f;
	public float currentHealth;

	public EnemyItemDrops itemDrop;
	public EnemyUpgradeDrops upgradeDrop;
    public Slider EnemyHealthBar;
    public AvatarController player;

    public bool itemDrops = true;
	public bool doubleJumpDrop = false;
	public bool armorUpgradeDrop = false;

    private float lastHitCounter;
    private bool showHealthBar = true;
    public float secondsToShowHealthBar = 1.0f;


    // Use this for initialization
    void Start () {

        EnemyHealthBar = gameObject.GetComponentInChildren<Slider>();
        player = GameObject.Find("Avatar").GetComponent<AvatarController>();
        EnemyHealthBar.gameObject.SetActive(false);


        currentHealth = enemyMaxHealth;
		//itemDrop = FindObjectOfType<EnemyItemDrops>();
        itemDrop = GetComponent<EnemyItemDrops>();
        upgradeDrop = GetComponent<EnemyUpgradeDrops>();

	}
	
	// Update is called once per frame
	void Update () {
        if (showHealthBar)
        {
            lastHitCounter += Time.deltaTime;
            if (lastHitCounter >= secondsToShowHealthBar)
            {
                showHealthBar = false;
                EnemyHealthBar.gameObject.SetActive(false);
                lastHitCounter = 0;
            }
        }

    }

	public void HurtEnemy(float damage)
    {
        currentHealth -= damage;
        player.score += (int)Math.Ceiling(damage);
        EnemyHealthBar.value = currentHealth/100f;
        EnemyHealthBar.gameObject.SetActive(true);
        showHealthBar = true;


        if (currentHealth <= 0)
        {
            player.score += 50;
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

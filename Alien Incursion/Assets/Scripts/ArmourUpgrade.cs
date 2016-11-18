using UnityEngine;
using System.Collections;

public class ArmourUpgrade : MonoBehaviour {

	public PlayerHealth player;

	// Use this for initialization
	void Awake () {
		player = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			player.IncreaseMaxArmour(75f);
			Destroy(this.gameObject);
        }
	}
}

using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public AvatarController avatar;
	public GameUI game;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType<GameUI>();
		avatar = FindObjectOfType<AvatarController>();		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			avatar.selfDestruct = true;

			if (avatar.selfDestruct) {
				game.SelfDestructTimer();
			}

			Destroy(this.gameObject);
        }
	}
}

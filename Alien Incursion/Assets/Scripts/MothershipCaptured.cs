using UnityEngine;
using System.Collections;

public class MothershipCaptured : MonoBehaviour {

	public GameUI game;
    public AvatarController avatar;

	// Use this for initialization
	void Start () {
		game = FindObjectOfType<GameUI>();
        avatar = FindObjectOfType<AvatarController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if (avatar.keycard) {
				game.Captured();
			}
        }
    }
}

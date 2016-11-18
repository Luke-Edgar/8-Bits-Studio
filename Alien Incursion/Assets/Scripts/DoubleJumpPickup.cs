﻿using UnityEngine;
using System.Collections;

public class DoubleJumpPickup : MonoBehaviour {

	public AvatarController avatar;

	// Use this for initialization
	void Awake () {
		avatar = FindObjectOfType<AvatarController>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			avatar.doubleJumpUnlocked = true;
			Destroy(this.gameObject);
        }
	}
}

using UnityEngine;
using System.Collections;

public class Keycard : MonoBehaviour {

	public AvatarController avatar;

	// Use this for initialization
	void Start () {
		avatar = FindObjectOfType<AvatarController>();		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			avatar.keycard = true;
			Destroy(this.gameObject);
        }
	}
}

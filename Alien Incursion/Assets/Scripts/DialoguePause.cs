using UnityEngine;
using System.Collections;

public class DialoguePause : MonoBehaviour {

	public AvatarController avatar;
	public int dialogueChoice = 0;

	public string [] dialogues = { "Intro", "Melee", "Shield", "Boss" };
	string dialogue;

	// Use this for initialization
	void Awake () {
		avatar = FindObjectOfType<AvatarController>();		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButtonDown ("Submit")) {
			avatar.disableInput = false;
		}
			
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			avatar.disableInput = true;
			avatar.RemoveForce();
			// Display text in UI
			// text to display = dialogueType;
			dialogue = dialogues[dialogueChoice];
			Debug.Log(dialogue);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}

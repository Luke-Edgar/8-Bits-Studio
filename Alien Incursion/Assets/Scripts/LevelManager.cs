using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	public AvatarController avatar;
	public PlayerHealth player;

	// Use this for initialization
	void Start () {
		avatar = FindObjectOfType<AvatarController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Respawn ()
	{
		avatar.transform.position = currentCheckpoint.transform.position;
		player.Spawn();
	}
}

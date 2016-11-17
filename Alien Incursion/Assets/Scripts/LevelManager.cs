using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

	public AvatarController avatar;
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		avatar = FindObjectOfType<AvatarController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        currentCheckpoint.transform.position = avatar.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Respawn ()
	{
        playerHealth.Spawn();
            avatar.transform.position = currentCheckpoint.transform.position;

	}
}

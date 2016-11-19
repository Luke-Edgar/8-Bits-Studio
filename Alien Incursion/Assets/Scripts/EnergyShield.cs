using UnityEngine;
using System.Collections;

public class EnergyShield : MonoBehaviour {

    public AvatarController avatar;
    public PlayerHealth player;

	// Use this for initialization
	void Start () {
        avatar = FindObjectOfType<AvatarController>();
        player = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (avatar.keycard) {
			gameObject.SetActive (false);
		} else if (!avatar.keycard) {
			gameObject.SetActive (true);
		}
			
    }

}

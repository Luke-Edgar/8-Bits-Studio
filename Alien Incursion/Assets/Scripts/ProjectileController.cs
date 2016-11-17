using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public float projectileSpeed;
	public AvatarController avatar;

	// Use this for initialization
	void Awake ()
	{
		myRB = GetComponent<Rigidbody2D> ();
		avatar = FindObjectOfType<AvatarController> ();

		if (avatar.facingRight) 
			myRB.AddForce (new Vector2 (1f, -0.1f) * projectileSpeed, ForceMode2D.Impulse);
		else if (!avatar.facingRight) 
			myRB.AddForce(new Vector2(-1f, -0.1f) * projectileSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

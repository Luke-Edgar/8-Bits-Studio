using UnityEngine;
using System.Collections;

public class EnemyProjectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public float projectileSpeed;
	public BossEnemy boss;

	// Use this for initialization
	void Awake ()
	{
		myRB = GetComponent<Rigidbody2D> ();
        boss = (BossEnemy)this.gameObject.GetComponent<BossEnemy>();

		if (boss.facingRight) {
			myRB.AddForce (new Vector2 (1f, 0) * projectileSpeed, ForceMode2D.Impulse);
		} else if (!boss.facingRight) {
			myRB.AddForce (new Vector2 (-1f, 0) * projectileSpeed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RemoveForce ()
	{
		myRB.velocity = new Vector2(0 , 0);
	}
}

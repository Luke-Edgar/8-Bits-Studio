using UnityEngine;
using System.Collections;

public class EnemyProjectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public float projectileSpeed;
	public BossEnemy boss;

	// Use this for initialization

        //this method is called AFTER this is instantiated and after we set the boss variable correctly
	public void DoAwake ()
	{
		myRB = GetComponent<Rigidbody2D> ();
        //boss = GetComponent<BossEnemy>();
        //set when instantiated in BossEnemy.cs


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

using UnityEngine;
using System.Collections;

public class MeleeEnemy : MonoBehaviour {

	public float chargeTime;
	public float enemySpeed;
	public bool facingRight;

    float startChargeTime;
	bool canFlip = true;
	Rigidbody2D enemyRB2D;


	// Use this for initialization
	void Start () {
		enemyRB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if (facingRight && other.transform.position.x < transform.position.x) {
				Invoke("Flip", 1);
				} else if (!facingRight && other.transform.position.x > transform.position.x) {
				Invoke("Flip", 1);
			}
			startChargeTime = Time.time + chargeTime;
        }
	}

    void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {
            if (startChargeTime <= Time.time) {
				if(!facingRight) enemyRB2D.AddForce(new Vector2(-1,0)*enemySpeed);
				else enemyRB2D.AddForce(new Vector2(1,0)*enemySpeed);
			}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			canFlip = true;
			enemyRB2D.velocity = new Vector2 (0, 0);
		}
	}

	void Flip ()
	{
		if(!canFlip) return;
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		canFlip = false;
	}
}

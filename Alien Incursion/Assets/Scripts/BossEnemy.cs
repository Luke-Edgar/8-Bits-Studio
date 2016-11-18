using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {

	public bool facingRight;
	public float enemySpeed;

	Rigidbody2D enemyRB2D;

	// Firing weapon

    public Transform weaponMuzzle;
    public Transform target;
    public GameObject projectile;
    public GameObject thisProjectile;
    public float fireRate = 5f;
    float nextFire = 0f;
    float range;
	float minDistance = 20f;
    float maxDistance = 50f;

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
				Flip();
			} else if (!facingRight && other.transform.position.x > transform.position.x) {
				Flip();
			}
		}
	}

    void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {
			fireProjectile ();
		}

		target = other.transform;

		range = Vector2.Distance (transform.position, target.position);

		if (range < minDistance) {
			if (!facingRight)
				enemyRB2D.AddForce (new Vector2 (1, 0) * enemySpeed);
			else
				enemyRB2D.AddForce (new Vector2 (-1, 0) * enemySpeed);
		} else if (range > maxDistance) {
				if (!facingRight)
					enemyRB2D.AddForce (new Vector2 (-1, 0) * enemySpeed);
				else
					enemyRB2D.AddForce (new Vector2 (1, 0) * enemySpeed);
			}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireProjectile ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (facingRight) {
                thisProjectile = (GameObject)Instantiate(projectile, weaponMuzzle.position, Quaternion.Euler (new Vector3 (0,0,0)));
			} else if (!facingRight) {
                thisProjectile = (GameObject) Instantiate(projectile, weaponMuzzle.position, Quaternion.Euler (new Vector3 (0,0,180f)));
			}
            thisProjectile.GetComponent<EnemyProjectileController>().boss = this;
            thisProjectile.GetComponent<EnemyProjectileController>().DoAwake();

        }
	}
}

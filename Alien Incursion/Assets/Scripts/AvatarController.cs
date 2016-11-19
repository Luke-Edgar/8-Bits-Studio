using UnityEngine;
using System.Collections;


public class AvatarController : MonoBehaviour
{


    public bool facingRight;
    public bool disableInput = false;
    public bool jump = false;
	public bool doubleJumpUnlocked = false;
	public bool keycard = false;
    public bool selfDestruct = false;

    public float maxSpeed = 10f;
    public float moveForce = 365f;
    public float jumpForce = 150f;


    public int score = 0;

    public int[] ammo = { 100, 0, 0 };
    public bool[] weapon = { true, false, false };
    public string[] weaponName = { "M4", "Ray Gun", "SFG" };
    public int selectedWeapon = 0;

    bool grounded;
    bool canDoubleJump;

    private Rigidbody2D rb2d;
    public Transform groundCheck;

    public GameUI game;

    // Firing weapon

    public Transform weaponMuzzle;
    public GameObject projectile;
    public float fireRate = 0.2f;
    float nextFire = 0f;


    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<GameUI>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump"))
        {

            if (disableInput)
            {
                return;
            }
            else if (!disableInput)
            {

                if (grounded)
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                    canDoubleJump = true;
                }
                else if (doubleJumpUnlocked)
                {
                    if (canDoubleJump)
                    {
                        canDoubleJump = false;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                        rb2d.AddForce(Vector2.up * jumpForce);
                    }
                    else {
                        return;
                    }
                }
                else {
                    return;
                }
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (disableInput)
        {
            return;
        }
        else if (!disableInput)
        {
            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * moveForce);

            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();

            // Player firing

            if (Input.GetAxisRaw("Fire1") > 0)
                fireProjectile();
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireProjectile()
    {
        if ((Time.time > nextFire) && ammo[selectedWeapon] > 0)
        {
            ammo[selectedWeapon]--;
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(projectile, weaponMuzzle.position, Quaternion.Euler(new Vector3(0, 0, -95f)));
            }
            else if (!facingRight)
            {
                Instantiate(projectile, weaponMuzzle.position, Quaternion.Euler(new Vector3(0, 0, 95f)));
            }
        }


    }

    public void RemoveForce()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    public void AddAmmo(int ammoAmount)
    {
        ammo[0] += ammoAmount;
        ammo[1] += ammoAmount;
        ammo[2] += ammoAmount;
    }

    public bool HasLowAmmo()
    {
        if (ammo[selectedWeapon] < 30) return true;
        return false;
    }

}

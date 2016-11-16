using UnityEngine;using System.Collections;public class AvatarController : MonoBehaviour {

   
    public bool facingRight;	public bool jump = false;	public float maxSpeed = 10f;	public float moveForce = 365f;	public float jumpForce = 150f;

   
    public int score = 0;

    public int [] ammo = { 100, 0 , 0 };
    public bool [] weapon = { true, false, false };
    public string [] weaponName = { "M4", "Ray Gun", "SFG" };


    private bool grounded = false;    private bool canDoubleJump;	private Rigidbody2D rb2d;    public Transform groundCheck;    public GameUI game;    // Use this for initialization    void Awake () 	{		rb2d = GetComponent<Rigidbody2D>();	}		// Update is called once per frame	void Update ()	{		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));		if (Input.GetButtonDown ("Jump")) {

            //test score -- remove this
            score = score + 10;
            //


            if (grounded)            {                rb2d.AddForce(Vector2.up * jumpForce);
                canDoubleJump = true;            } else            {                if(canDoubleJump)                {                    canDoubleJump = false;                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);                    rb2d.AddForce(Vector2.up * jumpForce);                }            }        }	}	void FixedUpdate ()	{		float h = Input.GetAxis ("Horizontal");		if (h * rb2d.velocity.x < maxSpeed)			rb2d.AddForce (Vector2.right * h * moveForce);		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);		if (h > 0 && !facingRight)			Flip ();		else if (h < 0 && facingRight)			Flip ();	}	void Flip ()	{		facingRight = !facingRight;		Vector3 theScale = transform.localScale;		theScale.x *= -1;		transform.localScale = theScale;	}}
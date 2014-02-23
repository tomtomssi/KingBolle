using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	Vector2 myPos;
	Vector2 groundCheckPos;
	Vector2 a;
	private bool grounded = false;
	private bool jump = false;
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 1000f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		a = GameObject.Find ("groundCheck").transform.position;
		myPos = new Vector2 (transform.position.x, transform.position.y);
		groundCheckPos = new Vector2 (a.x, a.y);
		grounded = isGrounded ();
		if (Input.GetButtonDown ("Jump") && grounded)
						jump = true;
	}

	public bool isGrounded(){
			bool result =  Physics2D.Linecast(myPos , groundCheckPos , 1 << LayerMask.NameToLayer("Ground"));

			return result;
		}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > moveForce)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if (jump) {
						// Add a vertical force to the player.
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
			
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}

	}
}

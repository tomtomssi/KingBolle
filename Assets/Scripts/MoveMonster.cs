using UnityEngine;
using System.Collections;

public class MoveMonster : MonoBehaviour {
	public float moveSpeed = 2f;
	private bool isFlipped = false;

	private float HP;
	private SpriteRenderer healthBarSR;
	public GameObject healthBar;
	private Vector2 healthScale;
	private bool direction;
	private GameObject scores;
	private GameObject playerHealth;
	private bool playerHit = false;

	// Use this for initialization
	void Awake () {
		HP = 3;
		scores = GameObject.FindGameObjectWithTag ("ScoreBoard");
		playerHealth = GameObject.Find ("PlayerHealth");
		healthBarSR = healthBar.GetComponent<SpriteRenderer> ();
		healthScale = healthBar.transform.localScale;
	}

	public void setDirection(bool dir){
		this.direction = dir;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (direction) {
			rigidbody2D.velocity = new Vector2 (transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);
		} else if(!direction){
			rigidbody2D.velocity = new Vector2 (-transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);
		}
	} 

	void OnCollisionEnter2D( Collision2D c ){
		if (c.gameObject.tag == "Death") {
						DieToFloor ();
				}
		if (c.gameObject.tag == "Player" && !playerHit) {
			playerHealth.GetComponent<PlayerHealth>().HurtPlayer();
			playerHit = true;
			StartCoroutine("waitForHit");
		}
				if (!isFlipped) {
						if (c.gameObject.tag == "Obstacle" || c.gameObject.tag == "Wall" || c.gameObject.tag == "Enemy") {
								Flip ();
								isFlipped = true;
				StartCoroutine("waitForTurn");
						}
				}
		}

	public void Flip(){
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
		}

	public void Hurt(){
		HP--;
			if (HP < 1) {
				scores.GetComponent<Points> ().setPoints ();
				Destroy (gameObject);
			} else {
				UpdateHealth ();
			}
		}

	public void DieToFloor(){
		rigidbody2D.fixedAngle = false;
		gameObject.collider2D.enabled = false;
		rigidbody2D.gravityScale = 8;
		rigidbody2D.AddForce(new Vector2(0, 2500));
	}
	
	public void UpdateHealth(){
			healthBarSR.material.color = Color.Lerp (Color.green, Color.red, 1 - HP * 0.01f);
			healthBarSR.transform.localScale = new Vector3 (healthScale.x * HP * 0.33f, 1, 1);
		}

	public IEnumerator waitForHit(){
		yield return new WaitForSeconds (1);
		playerHit = false;
		}
	public IEnumerator dieTimer(){
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);
	}
	public IEnumerator waitForTurn(){
		yield return new WaitForSeconds(0.1f);
		isFlipped = false;
		}
	}

using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public Rigidbody2D bullets;
	public int bulletSpeed;
	Rigidbody2D bulletClone;
	private bool facing = true;
	Rigidbody2D parent;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a")){
			facing = false;
		}

		if (Input.GetKey ("d")) {
				facing = true;
		}

		if(Input.GetButtonDown("Fire1")){
			parent = GameObject.Find("Player").rigidbody2D;
			bulletClone = (Rigidbody2D)Instantiate (bullets, transform.position, Quaternion.identity);
			if(facing){
				bulletClone.velocity = new Vector2(bulletSpeed + parent.velocity.x, 0);
			} else {
				bulletClone.velocity = new Vector2(-bulletSpeed + parent.velocity.x, 0);
			}
		}
	}

}

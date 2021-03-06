﻿using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	private bool isDead = false;
	private GameObject GameFlowManager;
	GameObject points;

	// Use this for initialization
	void Start () {
		GameFlowManager = GameObject.Find ("GameFlowManager");
		points = GameObject.FindGameObjectWithTag ("ScoreBoard");
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			StartCoroutine("restartLevel");
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Death") {
			Death ();
		}
	}
	
	public void Death(){
		rigidbody2D.fixedAngle = false;
		gameObject.collider2D.enabled = false;
		rigidbody2D.AddForce(new Vector2(-100, 3500));
		rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, 46);
		isDead = true;
	}
	
	public IEnumerator restartLevel(){
		yield return new WaitForSeconds(1.3f);
		GameFlowManager.GetComponent<GameFlowControl>().gameOver(points.GetComponent<Points>().getPoints());
		//Application.LoadLevel (0);
	}

}

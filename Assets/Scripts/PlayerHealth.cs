using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	private int health = 20;
	private GameObject Player;
	private bool isDead = false;
	public AudioSource ac;
		// Use this for initialization
		void Start ()
		{
		Player = GameObject.FindGameObjectWithTag ("Player");
		}

		public void HurtPlayer(){
		ac.Play ();
			health = health - 10;
		}
		// Update is called once per frame
		void Update ()
		{

		if (health <= 0 && !isDead) {
			Player.GetComponent<PlayerDeath>().Death();
			isDead = true;
		}

		gameObject.guiText.text = "HP: " + health;
	}
}


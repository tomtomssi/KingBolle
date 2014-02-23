using UnityEngine;
using System.Collections;

public class RockCollision : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

	void OnCollisionEnter2D(Collision2D c){
				if (c.gameObject.tag == "ground") {
				Destroy(gameObject);
				}
		if (c.gameObject.tag == "Enemy") {
						GameObject e = c.gameObject;
						e.GetComponent<MoveMonster> ().DieToFloor ();
				}
			if(c.gameObject.tag == "Player"){
				GameObject p = GameObject.FindGameObjectWithTag("Player");
				p.GetComponent<PlayerDeath>().Death();
		}
	}
}


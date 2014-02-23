using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public GameObject explosion;
	private GameObject dyingsOfPerson;
	public GameObject ac;
	private GameObject GUIScore;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.6f);
		dyingsOfPerson = GameObject.Find ("dyingsOfPerson");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<MoveMonster>().Hurt();
			Instantiate(explosion, transform.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
			Destroy(gameObject);
			ac = (GameObject)Instantiate(ac, dyingsOfPerson.transform.position, Quaternion.identity);
			Destroy(ac,1);
		}
	}

}

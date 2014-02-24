using UnityEngine;
using System.Collections;

public class TaustaTatu : MonoBehaviour {

	Vector3 newPos = new Vector3 (-1.397733f, 0.6581111f, 10.08733f);
	Vector3 originalPos;
	public bool behind = true;

	// Use this for initialization
	void Start () {
		originalPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (behind);
		if (behind) {
			StartCoroutine ("moveBGfront");
		} else if (!behind) {
			StartCoroutine ("moveBGback");
		}
	}

	public IEnumerator moveBGfront(){
		yield return new WaitForSeconds(10);
		iTween.FadeTo (transform.gameObject, 0, 2f);
		behind = false;
	}
	public IEnumerator moveBGback(){
		yield return new WaitForSeconds(10);
		iTween.FadeTo (transform.gameObject, 1, 2f);
		behind = true;
	}
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnRocks : MonoBehaviour {

	public GameObject fallingRocks;

	public AudioSource ac;

	private List<GameObject> arr;

	public float maxSpawnTimer;
	private float spawnTimer;

	private float spawnPointMinX = -11f;
	private float spawnPointMaxX = 6.5f;
	private float spawnPointY = -12f;
	private float spawnPointYMax = -11f;

	GameObject clone;

	void Start () {
		spawnTimer = maxSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (spawnTimer);
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 2 && spawnTimer > 1) {
			ac.Play();
				}
		if (spawnTimer < 0) {
			arr = new List<GameObject> ();
			for(int i = 0; i < 5; ++i){
			clone = (GameObject)Instantiate (fallingRocks, new Vector2(Random.Range (spawnPointMinX,spawnPointMaxX), Random.Range(spawnPointY,spawnPointYMax)), Quaternion.identity);
				arr.Add(clone);
				clone.rigidbody2D.gravityScale = 0;
				StartCoroutine("waitForAnimation");
			Destroy(clone, 2);
			}
			spawnTimer = maxSpawnTimer;
		}
	}

	public IEnumerator waitForAnimation(){
		yield return new WaitForSeconds(1);
		foreach (GameObject g in arr) {
						g.rigidbody2D.gravityScale = 1;
				}
	}
}

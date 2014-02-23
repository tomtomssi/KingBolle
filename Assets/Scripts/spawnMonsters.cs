using UnityEngine;
using System.Collections;

public class spawnMonsters : MonoBehaviour {
	public GameObject flyMonster;
	private Vector2 spawnPos;
	public float maxSpawnTimer;
	private float spawnTimer;
	private int spawnPointMinX = -32;
	private int spawnPointMaxX = 24;
	private int spawnPointY = -12;
	GameObject clone;


	// Use this for initialization
	void Start () {
		spawnTimer = maxSpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0) {
			clone = (GameObject)Instantiate(flyMonster, new Vector2(Random.Range(spawnPointMinX, spawnPointMaxX), spawnPointY), Quaternion.identity);
			spawnTimer = maxSpawnTimer;
			int randomNumber = Random.Range(0,10);
			clone.GetComponent<MoveMonster>().setDirection( randomNumber < 5 );
		}
	}
}


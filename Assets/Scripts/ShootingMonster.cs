using UnityEngine;
using System.Collections;

public class ShootingMonster : MonoBehaviour {
	private Vector2 spawnLeft;
	private Vector2 spawnRight;

	public float maxSpawnTimer;
	private float spawnTimer;

	public GameObject prefab;
	private GameObject clone;
	public GameObject laser;
	private GameObject laserClone;
	private Vector2 pointB;

	// Use this for initialization
	void Start () {
		spawnLeft = new Vector2 (-30f, -12f);
		spawnRight = new Vector2 (-8.6f, -12f);
		spawnTimer = maxSpawnTimer;
		pointB = new Vector2 (-6f, -15.7f);
	}
	
	// Update is called once per frame
	void Update () {
				spawnTimer -= Time.deltaTime;
				if (spawnTimer < 2 && spawnTimer > 1) {
				}
				if (spawnTimer <= 0) {
						clone = (GameObject)Instantiate (prefab, spawnLeft, Quaternion.identity);
			shootLaser();
						spawnTimer = maxSpawnTimer;
				}
		}
		void shootLaser(){
			laserClone = (GameObject)Instantiate (laser, clone.transform.position, Quaternion.identity);
		laserClone.transform.position = Vector2.MoveTowards (transform.position, pointB, Time.deltaTime * 0.01f);

		}
	}





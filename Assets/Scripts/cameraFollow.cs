using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public float xMargin = 2f;
	public float yMargin = 2f;
	public float xSmooth = 2f;
	public float ySmooth = 2f;
	public Vector2 maxXAndY = new Vector2(18f, -1f);
	public Vector2 minXAndY = new Vector2(5f, -5f);

	public Transform player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	bool CheckXMargin(){
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin(){
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TrackPlayer ();
	}

	void TrackPlayer(){
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		if (CheckXMargin ()) {
			targetX = Mathf.Lerp (transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}

		if (CheckYMargin ()) {
			targetY = Mathf.Lerp (transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		}

		targetX = Mathf.Clamp (targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp (targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}
}

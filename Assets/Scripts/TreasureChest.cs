using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour {

	private float amplitude = 0.2f;
	public float speed = 5f;
	public float x = 14.01121f;
	float yy;

	// Use this for initialization
	void Start () {
		yy = 4f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(x, yy + amplitude * Mathf.Sin (speed * Time.time), -5.51001f);
	}
}

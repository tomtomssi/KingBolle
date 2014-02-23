using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {
	public int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	public void setPoints(){
			score += 100;
		}
	// Update is called once per frame
	void Update () {
		gameObject.guiText.text = "Points: " + score;
	}
}

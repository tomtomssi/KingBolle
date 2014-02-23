using UnityEngine;
using System.Collections;

public class MainMusic : MonoBehaviour {
	public AudioSource ac;
	public static bool playing = false;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (ac);
		if (!playing) {
			ac.Play ();
			playing = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

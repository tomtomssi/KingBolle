using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	GameObject menu;
	GameObject gameFlowManager;
	private GameObject bullets;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("Menu");
		gameFlowManager = GameObject.Find ("GameFlowManager");
		bullets = GameObject.Find ("bullets");
	}
	
	// Update is called once per frame
	void Update () {

		if (!paused)
						menu.SetActive (false);

		if(Input.GetKeyDown(KeyCode.Escape)){
			paused = !paused;
			if(paused){
				menu.SetActive(false);
				gameFlowManager.GetComponent<GameFlowControl>().pauseGame();
			} else if(!paused){
				gameFlowManager.GetComponent<GameFlowControl>().unPauseGame();
			}
		}
	}
}

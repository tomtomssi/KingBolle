using UnityEngine;
using System.Collections;

public class GameFlowControl : MonoBehaviour {

	GameObject menu;
	GameObject bullets;
	GameObject gameOverMenu;

	TextMesh gameOverPoints;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag("Menu");
		bullets = GameObject.Find ("bullets");
		gameOverPoints = GameObject.Find ("GameOverPoints").GetComponent<TextMesh> ();
		gameOverMenu = GameObject.Find ("GameOverMenu");
		gameOverMenu.SetActive (false);

	}

	public void pauseGame(){
		Time.timeScale = 0;
		menu.SetActive (true);
		bullets.SetActive(false);
	}

	public void unPauseGame(){
		Time.timeScale = 1;
		menu.SetActive(false);
		bullets.SetActive(true);
	}

	public void gameOver(int points){
		Time.timeScale = 0;
		bullets.SetActive(false);
		gameOverMenu.SetActive (true);
		gameOverPoints.text = "Your points: " + points;
	}
}

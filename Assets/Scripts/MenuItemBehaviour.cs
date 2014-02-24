using UnityEngine;
using System.Collections;

public class MenuItemBehaviour : MonoBehaviour {

	public Color defaultColor;
	public GameObject text;

	// Use this for initialization
	void Start () {
		defaultColor = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseEnter(){
		text.renderer.material.color = Color.blue;
	}
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			iTween.PunchPosition(gameObject, new Vector3(1.0f, 0f, 0f), 1.0f);
			switch(gameObject.name){
				case "1":
					if(Time.timeScale != 1) Time.timeScale = 1;
					Application.LoadLevel("KingBolle");
					break;
				case "2":
					print ("JEE2");
					break;
				case "3":
					Application.Quit();
					break;
			}
		}
	}
	void OnMouseExit(){
		text.renderer.material.color = defaultColor;
	}
}
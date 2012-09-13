using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public GUIText velocityText, gameTitle;

    //Debug Mode flag
	public bool debugMode = false;
	
	private static GUIManager instance;
	
	// Use this for initialization
	void Start () {
		instance = this;

        //Main Menu: Title
		gameTitle.enabled = false;
		
		if(debugMode) {
			velocityText.enabled = true;
		} 
		else {
			velocityText.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Update Debug UI's Velocity value
	public static void UpdateVelocity(float vel){
		vel = Mathf.Round (vel);
		instance.velocityText.text = "Velocity: " + vel.ToString();
	}
}

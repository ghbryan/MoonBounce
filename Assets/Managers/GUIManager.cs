using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public GUIText velocityText;
	public bool debugUI = false;
	
	private static GUIManager instance;
	
	// Use this for initialization
	void Start () {
		instance = this;
		velocityText.enabled = debugUI;
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

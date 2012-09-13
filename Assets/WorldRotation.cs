using UnityEngine;
using System.Collections;

public class WorldRotation : MonoBehaviour {
	public float rotationSpeed = 10.0f;
	float angle;
	bool gameRunning = true;

	// Use this for initialization
	void Start () {
		angle = transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		
		if(Input.GetKeyUp(KeyCode.Return))
			gameRunning = !gameRunning;
		
		if(gameRunning)
			transform.Rotate (Vector3.back * rotationSpeed * dt);
	}
}

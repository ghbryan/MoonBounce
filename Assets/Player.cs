using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public Transform world;
	public float jumpIntensity = 200;
	
	public static float acceleration = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float dt = Time.deltaTime;
		
		//Determines proper orientation/gravity for player on planet surface.
		Vector3 planetCore = (world.position - transform.position).normalized;
		rigidbody.AddForce (planetCore * acceleration * rigidbody.mass);
		
		transform.rotation.SetFromToRotation(Vector3.up, planetCore);
		
		//Temporary game start
		if(Input.GetKey(KeyCode.Space)) {
			rigidbody.AddForce(0, jumpIntensity, 0);	
		}
	}
}

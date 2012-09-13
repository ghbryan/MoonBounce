using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public Transform world;
	public Vector3 jumpVelocity;
	
	public static float gravity = 20.0f;
	
	private bool jumping = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Determines proper orientation/gravity for player on planet surface.
		Vector3 planetCore = (world.position - transform.position).normalized;
		rigidbody.AddForce (planetCore * gravity);
		
		//Update Debug UI's Velocity value
		GUIManager.UpdateVelocity(rigidbody.velocity.y);
		
		transform.rotation.SetFromToRotation(Vector3.up, planetCore);
		
		if(Input.GetKey(KeyCode.Space) && !jumping) {
			rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
			jumping = true;
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
        //Temporary obstacle collision detection
        if(collision.gameObject.tag == "Obstacle") {
            Debug.Log ("Player hit obstacle. Game over.");
        }
        else {
            jumping = false;
        }
	}
	
	void OnCollisionExit()
	{
		jumping = true;	
	}
}

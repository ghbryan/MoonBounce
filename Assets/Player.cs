using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player instance;

    //the world we want gravity to attract us to
	public Transform world;

    //a Vector3 that forces the player up the y-axis 20f
	public static Vector3 jumpVelocity = new Vector3(0, 20f, 0);
	
	public static float gravity = 20.0f;

    //a safety for preventing doublejumps
	private static bool jumping = false;
	
	// Use this for initialization
	void Start () {
	    instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//Determines proper orientation/gravity for player on planet surface.
		Vector3 planetCore = (world.position - transform.position).normalized;
		rigidbody.AddForce (planetCore * gravity);
		
		//Update Debug UI's Velocity value
		GUIManager.UpdateVelocity(rigidbody.velocity.y);
		
		transform.rotation.SetFromToRotation(Vector3.up, planetCore);
	}

    //if i'm touching an object--i'm no longer jumping
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

    //if i'm not touching the ground--i'm jumping
	void OnCollisionExit()
	{
		jumping = true;	
	}

    //perform a jump
    public static void Jump() {

        //jump, if you're not already
        if(!jumping) {
            Player.instance.rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
            jumping = true;
        }
    }
}

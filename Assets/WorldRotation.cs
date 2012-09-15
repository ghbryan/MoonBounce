using UnityEngine;
using System.Collections;

public class WorldRotation : MonoBehaviour {

    //rotation speed of the world
	public static float rotationSpeed = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		transform.Rotate (Vector3.back * rotationSpeed * dt);
	}

    //a public set for the rotation speed of the world
    public static void SetRotation(float newRot) {
      rotationSpeed = newRot;
    }
}

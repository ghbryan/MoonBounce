using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {

    private static ObstacleManager instance;

    public Transform destructionZone;
    public Transform creationZone;

    //The Moon
    public GameObject world;

    //Fence prefab
    public GameObject fence;

    //List of obstacles alive
    private static List<GameObject> obstacleList = new List<GameObject>();

    //Object creation frequency
    float placeTimer = 1;

    // Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        placeTimer -= dt;
        Debug.Log ("PlaceTimer: " + placeTimer + "\nDeltaTime: " + dt);

        if(placeTimer < 0) {
            CreateObstacle();
            placeTimer = Random.Range (1.2f, 3.0f);
        }
	    
	}

    //Creates a new obstacle
    void CreateObstacle() {
        GameObject obstacle = (GameObject)Instantiate (fence);
        obstacle.transform.parent = world.transform;
        obstacleList.Add (obstacle);
    }

    //Validates and destroys obstacles upon collision
    public static void DestroyObstacle(GameObject obstacle) {
        if(obstacleList.Contains (obstacle)) {
            obstacleList.Remove (obstacle);
            Destroy(obstacle);
        }
    }

}

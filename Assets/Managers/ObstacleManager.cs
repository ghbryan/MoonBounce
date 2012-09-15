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
    private static List<GameObject> spawnedObstacles = new List<GameObject>();

    //while true, create obstacles
    public static bool buildObstacles = false;

    //enable obstacle creation
    public static void Create() {
        buildObstacles = true;
    }

    //disable obstacle creation
    public static void StopCreation() {
        buildObstacles = false;
    }

    //Object creation frequency
    float placeTimer = 1;

    // Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        //temporary build timer
        if(buildObstacles) {
            float dt = Time.deltaTime;
            placeTimer -= dt;
    
            if(placeTimer < 0) {
                CreateObstacle();
                placeTimer = Random.Range (1.2f, 3.0f);
            }
        }
	}

    //Creates a new obstacle
    void CreateObstacle() {
        GameObject obstacle = (GameObject)Instantiate (fence);
        obstacle.transform.parent = world.transform;
        spawnedObstacles.Add (obstacle);
        Debug.Log (spawnedObstacles.Count);
    }

    //Validates and destroys obstacles upon collision
    public static void DestroyObstacle(GameObject obstacle) {
        if(spawnedObstacles.Contains (obstacle)) {
            spawnedObstacles.Remove (obstacle);
            Destroy(obstacle);
        }
    }

}

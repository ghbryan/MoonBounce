using UnityEngine;
using System.Collections;

public class DestructionManager : MonoBehaviour {

    //Sends any object that collides with the destruction zone to be checked for removal
    void OnCollisionEnter(Collision collision) {
        ObstacleManager.DestroyObstacle(collision.gameObject);
    }
}

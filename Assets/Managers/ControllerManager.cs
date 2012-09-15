using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

    public ControllerManager instance;

	// Use this for initialization
	void Start () {
        instance = this;    //declare singleton
	}
	
	// Update is called once per frame
	void Update () {

	}

    //control scheme for gameplay
    public static void GameplayController() {
        if(Input.GetKey (KeyCode.Space)) {
            //signal the player to jump
            Player.Jump ();
        }
        else if(Input.GetKeyUp(KeyCode.Return)) {
            //return to main menu
            GameManager.ChangeState(GameManager.GameState.MainMenu);
        }
    }

    //control scheme for menus
    public static void MenuController() {
        if(Input.GetKeyUp(KeyCode.Return)) {
            //begin the game
            GameManager.ChangeState(GameManager.GameState.GameStart);
        }
    }
}

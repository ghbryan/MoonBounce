using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    //a declaration of valid GameStates
    public enum GameState {
        MainMenu,
        GameStart,
        GameOver
    }

    //current GameState of the game
    private static GameState currentState;

    //transition between states
    private static void SwitchState(GameState nextState)
    {
        //first we need to clean up the current state
        OnEnd();

        //now we can step into the next state
        currentState = nextState;

        //we'll start off by preparing the state
        OnStart();
    }

    //code to run on start of state
    private static void OnStart()
    {
        //looks for the proper prep code for the current state
        switch (currentState)
        {
        case GameState.MainMenu:
            WorldRotation.SetRotation (0.0f);
            break;
        case GameState.GameStart:
            ObstacleManager.Create ();
            WorldRotation.SetRotation (20.0f);
            break;
        case GameState.GameOver:

            break;
        default:

            break;
        }
    }

    //code to run on end of state
    private static void OnEnd()
    {
        //looks for the proper clean up code for the current state
        switch (currentState)
        {
        case GameState.MainMenu:

            break;
        case GameState.GameStart:

            break;
        case GameState.GameOver:

            break;
        default:

            break;
        }
    }


	// Use this for initialization
	void Start () {
        instance = this;    //declare singleton

        //sets the initial GameState to display main menu
        currentState = GameState.MainMenu;

        //runs first batch of prep code
        OnStart();

	}
	
	// Update is called once per frame
	void Update () {
            //looks for the proper update routine
    	    switch (currentState)
            {
            case GameState.MainMenu:
                    //looks for player input using the Menu control scheme
                    ControllerManager.MenuController();
                break;
            case GameState.GameStart:
                    //looks for player input using the Gameplay control scheme
                    ControllerManager.GameplayController();
                break;
            case GameState.GameOver:
                    //looks for player input using the Menu control scheme
                    ControllerManager.MenuController();
                break;
            default:

                break;
            }
    }

    //a public function for changing GameStates
    public static void ChangeState(GameState newState) {
        SwitchState (newState);
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainGUI : MonoBehaviour {
	//script reference 
	public GameObject gameController; 
	VariableControl variables;
	GameStateController gameState;
	wordBuildingController playController;

	// Use this for initialization
	void Awake () {
		//preserves the GUI between level loads
	}

	void Start () {
		//script reference
		variables = gameController.GetComponent<VariableControl>();
		gameState = gameController.GetComponent<GameStateController>();
        if (SceneManager.GetActiveScene().name == "WordMaking") {
			playController = GameObject.Find("GameController").GetComponent<wordBuildingController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		//during the main gameplay phase, displays a timer to indicate how long the game has been going on for
		if (SceneManager.GetActiveScene().name == "WordMaking") {
			if (GUI.Button (new Rect (100, 100, 100, 30), "End Game")) {
				playController.sendVariablestoScoreScreen();
                SceneManager.LoadSceneAsync("ScoreScreen");
			}
			//GUI.Box (new Rect (400, 50, 200, 30), "Word Making Phase");
		//displays the player's score during the scorescreen
		} else if (SceneManager.GetActiveScene().name == "ScoreScreen") {
			GUI.Box (new Rect (100, 100, 100, 30), "Score: " + variables.score);
		} else if (SceneManager.GetActiveScene().name == "CharacterSelect") {

		}
	}
}

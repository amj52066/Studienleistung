using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private PlayerManager myPlayerManager;
	private GameObject[] doors;

	// Use this for initialization
	void Start () {
		WinTrigger.OnGameFinished += GameFinished;
		PlayerManager.OnHealthChanged += HealthChanged;

		myPlayerManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerManager> ();
		myPlayerManager.SetDefaultHealth ();

		doors = GameObject.FindGameObjectsWithTag ("Door");
		Debug.Log ("Doors: " + doors.Length);
	}

	void GameFinished() {
		gameWon ();
	}

	void HealthChanged(int points) {
		if (points <= 0) {
			resetGame ();
		}
		Debug.Log ("Points: " + points);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void resetGame() {
		myPlayerManager.respawnPlayer();
	}

	void gameWon() {
		myPlayerManager.respawnPlayer();
		myPlayerManager.SetDefaultHealth ();
		closeAllDoors();
	}

	void closeAllDoors() {
		for (int i = 0; i < doors.Length; i++) {
			doors [i].GetComponent<Door> ().isOpen = false;
		}
	}
		
}

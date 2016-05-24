using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private PlayerManager myPlayerManager;
	private CanvasMan myCanvasMan;
	private GameObject[] doors;
	private GameObject[] bombs;

	// Use this for initialization
	void Start () {
		myCanvasMan = GameObject.Find("Canvas").GetComponent<CanvasMan>();
		WinTrigger.OnGameFinished += GameFinished;
		PlayerManager.OnHealthChanged += HealthChanged;

		myPlayerManager = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerManager> ();
		myPlayerManager.SetDefaultHealth ();

		doors = GameObject.FindGameObjectsWithTag ("Door");
		Debug.Log ("Doors: " + doors.Length);

		bombs = GameObject.FindGameObjectsWithTag ("Bomb");
	
	}

	void GameFinished() {
		gameWon ();
	}

	void HealthChanged(int points) {
		if (points <= 0) {
			GameLost ();
		}
		Debug.Log ("Points: " + points);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resetGame() {
		myPlayerManager.respawnPlayer();
	}

	public void gameWon() {
		myPlayerManager.respawnPlayer();
		myPlayerManager.SetDefaultHealth ();
		closeAllDoors();
		ReactivateAllBombs ();
	}

	void closeAllDoors() {
		for (int i = 0; i < doors.Length; i++) {
			doors [i].GetComponent<Door> ().isOpen = false;
		}
	}

	public void OnDoorButtonClicked() {
		
	}

	void ReactivateAllBombs(){
		for (int i = 0; i < bombs.Length; i++) {
			bombs [i].GetComponent<BombTrigger> ().DeactivateBomb(true);
		}
	}

	void GameLost() {
		ReactivateAllBombs ();
		closeAllDoors ();
		myPlayerManager.respawnPlayer ();
		myPlayerManager.SetDefaultHealth ();
	}

	private void resetTime(){
		myCanvasMan.ResetTime ();
	}
		
}

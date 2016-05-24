using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMan : MonoBehaviour {

	private string healthString = "Health: ";
	private Text healthText;
	private string timeString = "Time: ";
	private Text PlaytimeText;
	private GameObject winText;
	private GameObject lostText; 
	private GameObject timeTextObject;
	private Text timeText;
	private float Timer;
	private string timeFinishedString = "It took: ";
	private string secondsString = "seconds";
	private int waitingTime = 5;
	private float startTimer;
	private int currentHealth;
	private GameObject currentDoor;
	bool GameWon = false;
	private GameObject doorButton;


	// initialization
	void Start () {
		PlayerManager.OnHealthChanged += UpdateHealth;
		DoorTrigger.OnTriggerEntered += ShowButton;
		DoorTrigger.OnTriggerQuit += HideButton;
		//WinTrigger.OnGameFinished += GameFinished;

		healthText = GameObject.Find ("Canvas/HealthUI").GetComponent<Text> ();
		PlaytimeText = GameObject.Find ("Canvas/PlayTimeUI").GetComponent<Text> ();
		timeText = GameObject.Find ("Canvas/FinishTime").GetComponent<Text> ();
		Timer = 0.0f;
		winText = GameObject.Find ("Canvas/GameWon");
		lostText = GameObject.Find ("Canvas/GameLost");
		winText.GetComponent<Text> ().enabled = false;
		lostText.GetComponent<Text> ().enabled = false;
		timeTextObject = GameObject.Find("Canvas/FinishTime");
		timeTextObject.GetComponent<Text> ().enabled = false;
		doorButton = GameObject.Find ("Canvas/DoorButtonUI");
		doorButton.SetActive (false);
	}




	public void changeHealthUI(int currentHealth) {
		this.currentHealth = currentHealth;
		healthText.text = healthString + currentHealth;
	}

	public void showLostGame() {
		startTimer = Time.deltaTime;
		lostText.GetComponent<Text> ().enabled = true;
		showFinishedTime ();
	}

	public void showWonGame(){
		startTimer = Time.deltaTime;
		winText.GetComponent<Text> ().enabled = true;
		showFinishedTime ();
	}
		
	private void showFinishedTime () {
		float secsToWait = 5.0f;
		timeTextObject.GetComponent<Text> ().enabled = true;
		timeText.text = timeFinishedString + Timer + secondsString;
		StartCoroutine (Wait());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (5);
		closeAll();
		GameObject.Find ("GameManagerObject").GetComponent<GameManager> ().resetGame ();
	}
		
	private void closeAll() {
		timeTextObject.GetComponent<Text> ().enabled = false;
		winText.GetComponent<Text> ().enabled = false;
		lostText.GetComponent<Text> ().enabled = false;
	}

	public void ResetTime() {
		Timer = 0.0f; 
	}
		
	void Update () {
		Timer += Time.deltaTime;
		PlaytimeText.text = timeString + Timer;
	}

	void UpdateHealth(int currentHealth) {
		healthText.text = healthString + currentHealth;
	}

	void ShowButton(GameObject door) {
		if (door.GetComponent<Door> ().isOpen == false) {
			doorButton.SetActive (true);
			currentDoor = door;
		}
	}

	void HideButton(GameObject door) {
		currentDoor = null;
		doorButton.SetActive (false);
	}

	public void OnButtonClicked() {
		if (currentDoor != null) {
			currentDoor.GetComponent<Door> ().isOpen = true;
		}
	}

	//void GameFinished() {
		//messageScreen.SetActive (true);
		//time = Time.time - gameStartTime;
		//winText 
		//GameWon = true;
	//}
}

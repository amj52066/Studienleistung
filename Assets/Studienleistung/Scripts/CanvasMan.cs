using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMan : MonoBehaviour {

	private string healthString = "Health: ";
	private Text healthText;
	private string timeString = "Time: ";
	private Text PlayTimeText;
	private GameObject winText;
	private GameObject lostText; 
	private GameObject timeTextObject;
	private float Timer;
	private string timeFinishedString = "It took: ";
	private string secondsString = "seconds";
	private int waitingTime = 5;
	private float startTimer;
	private Text timeText;
	private float defaultTime;

	// Use this for initialization
	void Start () {
		healthText = GameObject.Find ("Canvas/HealthUI").GetComponent<Text> ();
		PlayTimeText = GameObject.Find ("Canvas/PlayTimeUI").GetComponent<Text> ();
		defaultTime = 0.0f;
		winText = GameObject.Find ("Canvas/GameWon");
		winText.SetActive (false);
		lostText = GameObject.Find ("Canvas/GameLost");
		lostText.SetActive (false);
		timeTextObject = GameObject.Find("Canvas/FinishTime");
		timeTextObject.SetActive (false);
		timeText = timeTextObject.GetComponent<Text> ();
	}

	public void changeHealthUI(int currentHealth) {
		healthText.text = healthString + currentHealth;
	}

	public void showGameLostUI() {
		startTimer = Time.deltaTime;
		lostText.SetActive (true);
		showPlayerTime();
	}

	public void showWinUI(){
		startTimer = Time.deltaTime;
		winText.SetActive (true);
		showPlayerTime();
	}

	private void showPlayerTime() {
		timeText.text = timeString + Timer + secondsString;
		timeTextObject.SetActive (true);
		while (Time.deltaTime - startTimer <= waitingTime){
		}
		deactivateTexts();
	}

	private void deactivateTexts() {
		timeTextObject.SetActive(false);
		winText.SetActive(false);
		lostText.SetActive(false);
	}
		
	void Update() {
		Timer += Time.deltaTime;
		//timeText.text = timeString + Timer;
	}
}

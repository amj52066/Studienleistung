using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    
	PlayerInputManager myInputManager;
	public Transform spawnPos;

	public delegate void PlayerEvent(int current);
	public static event PlayerEvent OnHealthChanged;

	private int defaultHealth = 100;
	public int myHealth;

	public int health {
		get {
			return myHealth;
		}

		set { 
			myHealth = value;
		}
	}

	public void decreaseHealth(int value) {
		myHealth -= value;
		OnHealthChanged (myHealth);
	}

	public void SetDefaultHealth() {
		Debug.Log ("Health decreased!");
		myHealth = defaultHealth;
		OnHealthChanged (myHealth);
	}
		
	void Start () {
		Init ();
	}

	void Init() {
		myInputManager = gameObject.GetComponent<PlayerInputManager>();
		myInputManager.Init();
		myInputManager.setPosition(spawnPos);
		OnHealthChanged(myHealth);
	}

	public void respawnPlayer() {
		myInputManager.setPosition(spawnPos);
	}
}

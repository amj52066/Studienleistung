using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public GameObject doorAction;
	private Door myDoor;
	private AudioSource sound;

	public delegate void ConsoleEvent(GameObject con);
	public static event ConsoleEvent OnTriggerEntered;
	public static event ConsoleEvent OnTriggerQuit;

	void Start () {
		sound = GetComponent<AudioSource>();
		myDoor = doorAction.GetComponent<Door> ();
	}

	void OnTriggerEnter(Collider myCollider) {
		if (myCollider.gameObject.name == "Player") {
			sound.Play();
			if (doorAction == null)
				Debug.Log ("Null");
			OnTriggerEntered(doorAction);
		}
	}

	void OnTriggerStay(Collider myCollider) {
		if (myCollider.gameObject.name == "Player") {
			if(Input.GetKey(KeyCode.Space)) {
				myDoor.isOpen = true;
			}
		}
	}

	void OnTriggerExit(Collider myCollider) {
		if (myCollider.gameObject.name == "Player") {
			OnTriggerQuit (doorAction);
		}
	}


}

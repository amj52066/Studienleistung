using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool isOpen = false;
	public float doorPos;
	public float openingHeight = 0.0f;
	public float closingHeight = 3.0f;
	public float closingSpeed = 5;

	void Start() {
		
	}

	void FixedUpdate () {
		doorPos = transform.position.y;
		if (isOpen) {
			openDoor ();
		} else {
			closeDoor ();
		}
	}

	void closeDoor() {
		if (doorPos < closingHeight) {
			transform.Translate (Vector3.up * closingSpeed * Time.deltaTime);
		}
	}

	void openDoor() {
		if (doorPos >= openingHeight) {
			transform.Translate (Vector3.down * closingSpeed * Time.deltaTime);
		}
	}

	public bool setDoor
	{
		get
		{
			return isOpen; 
		}

		set
		{
			isOpen = value;
		}
	}
}

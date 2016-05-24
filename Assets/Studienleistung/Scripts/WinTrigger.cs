using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	private GameManager myGameManager;

	void Start () {
		myGameManager = GetComponent<GameManager>();
	}

	void OnTriggerStart(Collider myCollider)
	{
		if(myCollider.gameObject.name == "Player") {
			//myGameManager.GameIsWon();
		}
	}



}

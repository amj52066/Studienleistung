using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	public delegate void WinEvent();
	public static event WinEvent OnGameFinished;

	private GameManager myGameManager;

	void Start () {
		myGameManager = GetComponent<GameManager>();
	}

	void OnTriggerEnter(Collider myCollider)
	{
		if(myCollider.gameObject.name == "Player") {
			Debug.Log ("reachedCollider");
			OnGameFinished ();
			//myGameManager.GameIsWon();
		}
	}



}

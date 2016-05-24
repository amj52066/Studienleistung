using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	public delegate void WinEvent();
	public static event WinEvent OnGameFinished;


	void OnTriggerEnter(Collider myCollider)
	{
		if(myCollider.gameObject.name == "Player") {
			Debug.Log ("reachedCollider");
			OnGameFinished ();
		}
	}



}

using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	public delegate void TriggerEvent();
	public static event TriggerEvent OnBombTriggered;

	public int bombState = 10;

	private AudioSource mySound;
	private BoxCollider mySphereCollider;
	private MeshRenderer myMesh;


	void Start () {
		mySphereCollider = gameObject.GetComponent<BoxCollider> ();
		myMesh = gameObject.GetComponent<MeshRenderer> ();
		mySound = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerStart(Collider myCollider) {
		if (myCollider.gameObject.name == "Player") {
			DeactivateBomb(false);
			mySound.Play();
			myCollider.gameObject.GetComponent<PlayerManager>().decreaseHealth(bombState);
		}
	}

	public void DeactivateBomb(bool active) {
		mySphereCollider.enabled = active;
		myMesh.enabled = active;
	}

}

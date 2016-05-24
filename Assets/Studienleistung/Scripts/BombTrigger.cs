using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	public delegate void TriggerEvent();
	public static event TriggerEvent OnBombTriggered;

	public int bombState = 10;

	private SphereCollider mySphereCollider;
	private MeshRenderer myMesh;


	void Start () {
		mySphereCollider = gameObject.GetComponent<SphereCollider> ();
		myMesh = GetComponent<MeshRenderer> ();
	}

	void OnTriggerEnter(Collider myCollider) {
		if (myCollider.gameObject.name == "Player") {
			Debug.Log ("Bomb reached!");
			DeactivateBomb(false);
			myCollider.gameObject.GetComponent<PlayerManager>().decreaseHealth(bombState);
		}
	}

	public void DeactivateBomb(bool active) {
		mySphereCollider.enabled = active;
		myMesh.enabled = active;
	}

}

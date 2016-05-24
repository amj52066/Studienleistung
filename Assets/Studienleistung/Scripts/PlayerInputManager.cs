using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	private Rigidbody myRigidbody;

	public float mySpeed = 10f;
	public float myRotationSpeed = 100f;

	private string myMovementName ="Move" ;
	private string myRotationName ="Rotate";

	private float myInputMov = 0.0f;
	private float myInputRot;


	void Start () {

	}

	public void Init() {
		myRigidbody = GetComponent<Rigidbody> ();
	}

	private void Move() {
		myInputMov = Input.GetAxis (myMovementName);
		Vector3 mov = (transform.forward * myInputMov * mySpeed * Time.deltaTime);
		myRigidbody.MovePosition (myRigidbody.position + mov);
	}

	private void Rotate() {
		myInputRot = Input.GetAxis (myRotationName);
		float rotate = myInputRot * myRotationSpeed * Time.deltaTime;
		Quaternion turnRot = Quaternion.Euler (0f, rotate, 0f);
		myRigidbody.MoveRotation (myRigidbody.rotation * turnRot);
	}

	public void setPosition(Transform spawnPos) {
		myRigidbody.position = spawnPos.position;
	}
		
	void FixedUpdate () {
		Move ();
		Rotate ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {
	public int elevatorNum;
	private Rigidbody2D myScriptsRigidbody2D;
	public bool isOn = false;
	[SerializeField] float maxSpeed = 1;
	void Awake() {
		Application.targetFrameRate = 300;
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "DeadPlayer") {
			isOn = true;
			//Debug.Log ("player is on");
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "DeadPlayer") {
			other.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.029f, this.transform.position.z);
		}
	}

	void Start () {
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update(){
		if(isOn){
			if(elevatorNum == 1){
				if(myScriptsRigidbody2D.velocity.magnitude < maxSpeed)
				{
				myScriptsRigidbody2D.AddForce(new Vector3(0.474f, 0.642f, 1) * 3); // just an example.
				}
			}
			if(elevatorNum == 2){
				if(myScriptsRigidbody2D.velocity.magnitude < maxSpeed){
				myScriptsRigidbody2D.AddForce(new Vector3(-0.474f, 0.642f, 1) * 3); // just an example.
				}
			}
		}
}
}

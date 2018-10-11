using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorStopScript : MonoBehaviour {
	public string elevatorTag;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == elevatorTag) {
			other.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			Destroy(other.gameObject);
		}
	}

}

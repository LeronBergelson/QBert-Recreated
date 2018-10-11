using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyDeathRestart : MonoBehaviour {
	public bool coilyDied = false;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "deadCoily") {
			coilyDied = true;
			Invoke ("Restart", 3);
		}

	}

	void Restart()
	{
		coilyDied = false;
	}

}

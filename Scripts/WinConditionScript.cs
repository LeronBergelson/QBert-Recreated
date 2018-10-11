using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionScript : MonoBehaviour {
	int score;
	[SerializeField] GameObject winPyramid;

	private bool onetime = false;

	// Update is called once per frame
	void Update () {
		score = (GameObject.FindGameObjectsWithTag("Touched").Length) * 25;

		if(score == 700){
			if (!onetime) {
				Instantiate (winPyramid, new Vector3 (0.695f, 2.471f, 0), Quaternion.identity);
				onetime = true;

			}
		}
	}

}

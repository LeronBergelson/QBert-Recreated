using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
	public Transform canvas;

	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
				Cursor.visible = true;


			} else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
				Cursor.visible = false;

			}
		}
	}
}

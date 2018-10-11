using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour {
	// Use this for initialization
	public void Resume() {
		this.gameObject.SetActive (false);
		Time.timeScale = 1;
		Cursor.visible = false;
	}

}

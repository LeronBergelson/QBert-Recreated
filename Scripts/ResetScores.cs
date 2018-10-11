using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScores : MonoBehaviour {

	public void Reset() {
			
		PlayerPrefs.SetInt ("Count", 0);

		PlayerPrefs.SetString ("Name", "Empty");
		PlayerPrefs.SetInt ("Score", 0);
		 	
		PlayerPrefs.SetString ("Name2", "Empty");
		PlayerPrefs.SetInt ("Score2", 0);

		PlayerPrefs.SetString ("Name3", "Empty");
		PlayerPrefs.SetInt ("Score3", 0);

		PlayerPrefs.SetString ("Name4", "Empty");
		PlayerPrefs.SetInt ("Score4", 0);

		PlayerPrefs.SetString ("Name5", "Empty");
		PlayerPrefs.SetInt ("Score5", 0);

		PlayerPrefs.SetString ("Name6", "Empty");
		PlayerPrefs.SetInt ("Score6", 0);

		PlayerPrefs.SetString ("Name7", "Empty");
		PlayerPrefs.SetInt ("Score7", 0);

		PlayerPrefs.SetString ("Name8", "Empty");
		PlayerPrefs.SetInt ("Score8", 0);

		PlayerPrefs.SetString ("Name9", "Empty");
		PlayerPrefs.SetInt ("Score9", 0);

		PlayerPrefs.SetString ("Name10", "Empty");
		PlayerPrefs.SetInt ("Score10", 0);
	
		DoSceneChange ();
	}

	void DoSceneChange()
	{
		SceneManager.LoadScene("HighScore");

	}

}

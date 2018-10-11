using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] string levelToLoad;

	public void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
	}

}


	
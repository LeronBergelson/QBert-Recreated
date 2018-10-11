using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;
	ScoreManager scoreManager;
	int lastChangeCounter;
	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
		lastChangeCounter = scoreManager.GetchangeCounter ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreManager == null) {
			Debug.LogError ("You forgot to add thr score manager component to a game object!");
		}


		if (scoreManager.GetchangeCounter () == lastChangeCounter) {
			//No change since last update
			return;

		}

		lastChangeCounter = scoreManager.GetchangeCounter ();

		while (this.transform.childCount > 0) {
			Transform c = this.transform.GetChild(0);
			c.SetParent (null);
			Destroy (c.gameObject);
		}

		string[] names = scoreManager.GetPlayerNames ("Score");

		foreach(string name in names) {
			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("Username").GetComponent<Text> ().text = name;
			go.transform.Find ("Score").GetComponent<Text> ().text = scoreManager.GetScore(name, "Score").ToString();

		}
	}
}

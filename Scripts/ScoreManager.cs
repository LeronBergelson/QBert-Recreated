using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour {
	Dictionary<string, Dictionary<string, int>> playerScores;
	int changeCounter = 0;

	void Start(){
	//	PlayerPrefs.SetInt ("Count", PlayerPrefs.GetInt("Count" + 1));

		//for(int i = 0; i <  PlayerPrefs.GetInt ("Count"); i++){
	//	SetScore (PlayerPrefs.GetString ("Name"), "Score", PlayerPrefs.GetInt ("Score"));
		//}
	//	SetScore ("leron", "Score", 26);

		//SetScore ("bob", "wins", 9001);

	//	Debug.Log(GetScore("quill18", "Score"));


		if(PlayerPrefs.GetInt("Count") >= 1){
			SetScore (PlayerPrefs.GetString ("Name1"), "Score", PlayerPrefs.GetInt ("Score1"));

		}


		if(PlayerPrefs.GetInt("Count") >= 2){
			SetScore (PlayerPrefs.GetString ("Name2"), "Score", PlayerPrefs.GetInt ("Score2"));

		}

		if(PlayerPrefs.GetInt("Count") >= 3){
			SetScore (PlayerPrefs.GetString ("Name3"), "Score", PlayerPrefs.GetInt ("Score3"));

		}

		if(PlayerPrefs.GetInt("Count") >= 4){
			SetScore (PlayerPrefs.GetString ("Name4"), "Score", PlayerPrefs.GetInt ("Score4"));

		}

		if(PlayerPrefs.GetInt("Count") >= 5){
			SetScore (PlayerPrefs.GetString ("Name5"), "Score", PlayerPrefs.GetInt ("Score5"));

		}

		if(PlayerPrefs.GetInt("Count") >= 6){
			SetScore (PlayerPrefs.GetString ("Name6"), "Score", PlayerPrefs.GetInt ("Score6"));

		}

		if(PlayerPrefs.GetInt("Count") >= 7){
			SetScore (PlayerPrefs.GetString ("Name7"), "Score", PlayerPrefs.GetInt ("Score7"));

		}

		if(PlayerPrefs.GetInt("Count") >= 8){
			SetScore (PlayerPrefs.GetString ("Name8"), "Score", PlayerPrefs.GetInt ("Score8"));

		}

		if(PlayerPrefs.GetInt("Count") >= 9){
			SetScore (PlayerPrefs.GetString ("Name9"), "Score", PlayerPrefs.GetInt ("Score9"));

		}

		if(PlayerPrefs.GetInt("Count") == 10){
			SetScore (PlayerPrefs.GetString ("Name10"), "Score", PlayerPrefs.GetInt ("Score10"));

		}

  	}

	void Init(){
		if (playerScores != null)
			return;
		
		playerScores = new Dictionary<string, Dictionary<string, int>> ();
	}

	public int GetScore(string username, string scoreType){
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			return 0;
		}

		if (playerScores [username].ContainsKey (scoreType) == false) {
			return 0;
		}

		return playerScores [username] [scoreType];
	}


	public void SetScore(string username, string scoreType, int value){
		Init ();
		changeCounter++;
		if (playerScores.ContainsKey (username) == false) {
			playerScores [username] = new Dictionary<string, int> ();
		}
		playerScores [username][scoreType] = value;
	}

	public string[] GetPlayerNames(){
		Init ();
		return playerScores.Keys.ToArray ();
	}

	public string[] GetPlayerNames(string sortingScoreType){
		Init ();
		return playerScores.Keys.OrderByDescending (n => GetScore(n, sortingScoreType)).ToArray();
			}

	public int GetchangeCounter(){
		return changeCounter;
	}
}

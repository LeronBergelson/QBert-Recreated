using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

	public int score;
	private Rigidbody2D myScriptsRigidbody2D;
	public Text scoreAdd;
	private bool isOnEdgeRight = false;
	private bool isOnTop = false;
	private bool isOnEdgeLeft = false;
	public int sortingOrder = 0;
	private SpriteRenderer sprite;
	[SerializeField] GameObject cursePrefab;
	[SerializeField] GameObject life1;
	[SerializeField] GameObject life2;
	[SerializeField] Transform playerSpawn;
	[SerializeField] string levelToLoad;
	//private Transform playerSpawn;
	public float timeBetweenShots = 0.55f; 
	private float timestamp;
	private bool isOnElevator = false;

	private GameObject curse;
	private GameObject curse2;
	private GameObject curse3;

	public bool didWin = false;
	public bool isDead = false;
	public float lives = 3;

	public Transform canvas;
	public Transform winCanvas;

	public AudioClip bounceSound;
	public AudioClip deathSound;
	public AudioClip elevatorSound;
	public AudioClip deathFallSound;
	public AudioClip greenBallsound;
	public AudioClip winSound;

	private AudioSource source;

	public bool didPlay = false;
	private int tileCount;

	private int elevator1Count = 0;
	private int elevator2Count = 0;
	private int levelClearPoints = 1000;
	private int greenBallPoints;
	private int elevatorPoints;
	public int coilyDeathPoints;

	public int playerPrefCheck = 0;

	public Text finalScoreText;
	public Text coilyDeathText;
	public Text elevatorPointsText;
	public Text greenBallText;


	public bool didTouchGreenBall = false;
	public InputField nameInputField;
	public string playerName = "No Name";
	public int finalScore;

	private bool isColliding = false;
	public bool isTouchingTile = false;

	public Sprite leftJumpUp;
	public Sprite leftJumpDown;
	public Sprite rightJumpUp;
	public Sprite rightJumpDown;

	public bool didLeftJumpUp = false;
	public bool didLeftJumpDown = false;
	public bool didRightJumpUp = false;
	public bool didRightJumpDown = true;


	void Awake() {
		Application.targetFrameRate = 600;
	}

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		//Time.timeScale = 1;
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
		isDead = true;
		//Debug.Log (PlayerPrefs.GetInt ("Count"));
	}

	// Update is called once per frame
	void Update () {
		Time.timeScale = 1.3f;
		scoreAdd.text = score.ToString() ;
		finalScoreText.text = "Score: " + score;
		greenBallText.text =  "+" + greenBallPoints.ToString() + " Catching Green Ball Bonus";
		elevatorPointsText.text =  "+" + (elevatorPoints * 100).ToString() + " Elevators Remaining Bonus" ;
		coilyDeathText.text = "+" + coilyDeathPoints.ToString() + " Coily Death Bonus" ;

		tileCount = (GameObject.FindGameObjectsWithTag("Touched").Length);
		elevator1Count = (GameObject.FindGameObjectsWithTag("Elevator1").Length);
		elevator2Count = (GameObject.FindGameObjectsWithTag("Elevator2").Length);

		isColliding = false;

		if (tileCount == 28) {
			if(!didPlay){
				didWin = true;
				didPlay = true;
				score += 1000;
				if (elevator1Count == 1) {
					score += 100;
					elevatorPoints++;
				}
				if (elevator2Count == 1) {
					score += 100;
					elevatorPoints++;
				}
				gameObject.GetComponent<Rigidbody2D> ().simulated = false;
				source.PlayOneShot (winSound);
					if (winCanvas.gameObject.activeInHierarchy == false) {
					Invoke ("setVictoryScreen", 2);
					Cursor.visible = true;

					}
			}
		}

		if((Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKey(KeyCode.RightArrow)) && Time.time >= timestamp && isTouchingTile){
			if(!isDead && !didWin){
				source.PlayOneShot (bounceSound);
				timestamp = Time.time + timeBetweenShots;
				myScriptsRigidbody2D.AddForce(Vector2.up * 16.5f);
				myScriptsRigidbody2D.AddForce(new Vector3(0.474f, -0.702f, 1) * 13); // just an example.
				isTouchingTile = false;
				sprite.sprite = rightJumpDown;

			    didLeftJumpUp = false;
				didLeftJumpDown = false;
				didRightJumpUp = false;
				didRightJumpDown = true;


			}
		}

		if((Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKey(KeyCode.LeftArrow)) && Time.time >= timestamp && isTouchingTile){
			if(!isDead && !didWin){
				source.PlayOneShot (bounceSound);
				timestamp = Time.time + timeBetweenShots;
				myScriptsRigidbody2D.AddForce(Vector2.up * 16.5f);
				myScriptsRigidbody2D.AddForce(new Vector3(-0.474f, 0.702f, 1) * 13); // just an example.
				isTouchingTile = false;
				sprite.sprite = leftJumpUp;
					
				didLeftJumpUp = true;
				didLeftJumpDown = false;
				didRightJumpUp = false;
				didRightJumpDown = false;

			}
			if(isOnEdgeLeft || isOnTop){
				Invoke("LaunchProjectile", 1);
				transform.gameObject.tag = "DeadPlayer"; 
	 		}
		}

		if((Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKey(KeyCode.UpArrow)) && Time.time >= timestamp && isTouchingTile){
			if(!isDead && !didWin){
				source.PlayOneShot (bounceSound);
				timestamp = Time.time + timeBetweenShots;
				myScriptsRigidbody2D.AddForce (Vector2.up * 17f);
				myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, 0.702f, 1) * 13); // just an example.
				isTouchingTile = false;
				sprite.sprite = rightJumpUp;

				didLeftJumpUp = false;
				didLeftJumpDown = false;
				didRightJumpUp = true;
				didRightJumpDown = false;

			}
				if (isOnEdgeRight || isOnTop) {
					Invoke ("LaunchProjectile", 1);
					transform.gameObject.tag = "DeadPlayer"; 
				}
		}

		if((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKey(KeyCode.DownArrow))&& Time.time >= timestamp && isTouchingTile){
			if(!isDead && !didWin){
				source.PlayOneShot (bounceSound);
				timestamp = Time.time + timeBetweenShots;
				myScriptsRigidbody2D.AddForce (Vector2.up * 16.5f);
				myScriptsRigidbody2D.AddForce (new Vector3 (-0.474f, -0.702f, 1) * 13); // just an example.
				isTouchingTile = false;
				sprite.sprite = leftJumpDown;

				didLeftJumpUp = false;
				didLeftJumpDown = true;
				didRightJumpUp = false;
				didRightJumpDown = false;


			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Elevator2" || other.tag == "Elevator1") {
			sprite.sortingOrder = 6;
			myScriptsRigidbody2D.velocity = Vector2.zero;
			isOnElevator = true;
			source.PlayOneShot (elevatorSound);
		}
		if (other.tag == "Top") {
			isOnEdgeRight = false;
			isOnEdgeLeft = false;
			isOnTop = true;
			isOnElevator = false;
			isTouchingTile = true;
		}

		if (other.tag == "SetAlive") {
			sprite.sortingOrder = 6;
			transform.gameObject.tag = "Player";
			isDead = false;
			isTouchingTile = true;


		}

		if (other.tag == "UntouchedOuterRight") {
			isOnEdgeRight = true;
			isOnEdgeLeft = false;
			isOnTop = false;
			isTouchingTile = true;

		}
		if (other.tag == "UntouchedOuterLeft") {
			isOnEdgeRight = false;
			isOnEdgeLeft = true;
			isOnTop = false;
			isTouchingTile = true;

		}
		if (other.tag == "Untouched") {
			isOnEdgeRight = false;
			isOnEdgeLeft = false;
			isOnTop = false;
			isTouchingTile = true;

		}
		if (other.tag == "LowerBase") {
			isOnEdgeRight = false;
			isOnEdgeLeft = false;
			isOnTop = false;
			isTouchingTile = true;

		}
		if (other.tag == "Untouched") {
			isOnEdgeRight = false;
			isOnEdgeLeft = false;
			isOnTop = false;
			isTouchingTile = true;

		}

		if (other.tag == "Coily" || other.tag == "Enemy" || other.tag == "CoilyBall") {
			if (!isOnElevator) {
				if (gameObject.tag != "DeadPlayer"){
					if(isColliding) return;
					isColliding = true;
					Debug.Log ("Coily Did Touch");
					source.PlayOneShot (deathSound);
					gameObject.GetComponent<Rigidbody2D> ().simulated = false;
					lives -= 1.0f;
					if (lives == 2.0f){
						curse = Instantiate (cursePrefab, new Vector3 (this.transform.position.x + 0.05f, this.transform.position.y + 0.05f, this.transform.position.z), Quaternion.identity);
						isDead = true;
						Invoke ("endGame", 2);
					}
					if (lives == 1.0f) {
						curse2 = Instantiate (cursePrefab, new Vector3 (this.transform.position.x + 0.05f, this.transform.position.y + 0.05f, this.transform.position.z), Quaternion.identity);
						isDead = true;
						Invoke ("endGame", 2);


					}
					if (lives == 0.0f) {
						curse3 = Instantiate (cursePrefab, new Vector3 (this.transform.position.x + 0.05f, this.transform.position.y + 0.05f, this.transform.position.z), Quaternion.identity);
						isDead = true;
						Invoke ("endGame", 2);


					}
				}
			}
		}

		if (other.tag == "DeathFall") {
			isDead = true;
			gameObject.GetComponent<Rigidbody2D> ().simulated = false;
			lives -= 1.0f;
			Invoke ("DeathFallEndGame", 2);
		}

		if (other.tag == "GreenBall") {
			didTouchGreenBall = true;
			other.gameObject.SetActive (false);
			source.PlayOneShot (greenBallsound);
			Invoke ("setActive", 5);
			score += 100;
			greenBallPoints += 100;

		}

	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Elevator2" || other.tag == "Elevator1") {
			sprite.sortingOrder = 6;
		}
	}

	void LaunchProjectile(){
		sprite.sortingOrder = sortingOrder;
			if(!isOnElevator)
				source.PlayOneShot (deathFallSound);
	}

	void setVictoryScreen(){
		winCanvas.gameObject.SetActive (true);
	}

	void setActive(){
		didTouchGreenBall = false;
	}

	void endGame(){
		if (lives == 2.0f){
			isDead = false;
			Destroy (life1);
			Destroy(curse);
			gameObject.GetComponent<Rigidbody2D> ().simulated = true;
		}
		if(lives == 1.0f){
			isDead = false;
			Destroy (life2);
			Destroy(curse2);
			gameObject.GetComponent<Rigidbody2D> ().simulated = true;
		}
		if(lives == 0){
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Invoke("DoSceneChange", 2);
			}
		}

	}
		
	void DeathFallEndGame(){
		if (lives == 2.0f){
			isDead = false;
			Destroy (life1);
			sprite.sortingOrder = 6;
			transform.gameObject.tag = "Player";
			gameObject.GetComponent<Rigidbody2D> ().simulated = true;
			transform.position = new Vector3(0.553f, 2.805f, 0f);
		}
		if(lives == 1.0f){
			isDead = false;
			Destroy (life2);
			sprite.sortingOrder = 6;
			transform.gameObject.tag = "Player";
			gameObject.GetComponent<Rigidbody2D> ().simulated = true;
			transform.position = new Vector3(0.553f, 2.805f, 0f);
		}
		if(lives == 0){
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Invoke("DoSceneChange", 2);
		}
		}
	}

	void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
		Cursor.visible = true;

	}


	public void setget(){
		playerName = nameInputField.text;
		finalScore = score;

		PlayerPrefs.SetInt("Count", (PlayerPrefs.GetInt("Count")+1));

		if(PlayerPrefs.GetInt("Count") == 1){
			PlayerPrefs.SetString ("Name1", playerName);
			PlayerPrefs.SetInt ("Score1", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 2){
			PlayerPrefs.SetString ("Name2", playerName);
			PlayerPrefs.SetInt ("Score2", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 3){
			PlayerPrefs.SetString ("Name3", playerName);
			PlayerPrefs.SetInt ("Score3", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 4){
			PlayerPrefs.SetString ("Name4", playerName);
			PlayerPrefs.SetInt ("Score4", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 5){
			PlayerPrefs.SetString ("Name5", playerName);
			PlayerPrefs.SetInt ("Score5", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 6){
			PlayerPrefs.SetString ("Name6", playerName);
			PlayerPrefs.SetInt ("Score6", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 7){
			PlayerPrefs.SetString ("Name7", playerName);
			PlayerPrefs.SetInt ("Score7", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 8){
			PlayerPrefs.SetString ("Name8", playerName);
			PlayerPrefs.SetInt ("Score8", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 9){
			PlayerPrefs.SetString ("Name9", playerName);
			PlayerPrefs.SetInt ("Score9", finalScore);

		}

		if(PlayerPrefs.GetInt("Count") == 10){
			PlayerPrefs.SetString ("Name10", playerName);
			PlayerPrefs.SetInt ("Score10", finalScore);

		}
			

		Invoke ("DoSceneChange", 0);

	}
}
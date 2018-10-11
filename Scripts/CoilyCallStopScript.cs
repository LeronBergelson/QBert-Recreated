using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyCallStopScript : MonoBehaviour {
	[SerializeField] GameObject enemyPrefab;
//	private GameObject enemyPrefab;
	private Rigidbody2D myScriptsRigidbody2D;
	private int directionChoice;
	private int minVal = 0;
	private int maxVal = 2;

	public AudioClip bounceSound;
	private AudioSource source;

	private bool didLand = false;

	float timeLeft = 5.0f;


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Coily" && other.tag != "CoilyBall"  && other.tag != "Player" && other.tag != "Touched" && other.tag != "Elevator1" 
			&& other.tag != "Elevator2" && other.tag != "DeathFall" && other.tag != "DeadPlayer" && other.tag != "ElevatorStop" && other.tag != "CoilyStop" && other.tag != "GreenBall" && other.tag != "SetActive") {

			source.PlayOneShot (bounceSound);

		directionChoice = Random.Range(minVal, maxVal);

		if(!didLand){
			if (directionChoice == 0) {
				myScriptsRigidbody2D.AddForce(Vector2.up * 16.0f);
				myScriptsRigidbody2D.AddForce(new Vector3(-0.474f, -0.702f, 1) * 7);
				CancelInvoke ();
		}

			if (directionChoice == 1) {
				myScriptsRigidbody2D.AddForce(Vector2.up * 16.0f);
				myScriptsRigidbody2D.AddForce(new Vector3(0.474f, -0.702f, 1) * 7); 
				CancelInvoke ();
			}
		}
	  }
		if (other.tag == "LowerBase") {
			didLand = true;
			myScriptsRigidbody2D.GetComponent<Rigidbody2D> ().simulated = false;

		}
	}

	void Awake() {
		Application.targetFrameRate = 300;
	}

	void Start () {
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();

	}

	void Update() {
		GameObject reference2 = GameObject.Find("Player");
		PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();

		if (didLand) {
			Invoke ("SpawnCoily", 1);
			didLand = false;
		}

		if (playerScript3.isDead == true || playerScript3.didWin == true) {
			gameObject.GetComponent<Rigidbody2D> ().simulated = false;

			Invoke("Restart", 2);

		}

		if (playerScript3.didTouchGreenBall == true) {
			timeLeft -= Time.deltaTime;
			if (timeLeft > 0) {
				gameObject.GetComponent<Rigidbody2D> ().simulated = false;
			} else {
				gameObject.GetComponent<Rigidbody2D> ().simulated = true;
			}
		}

	}

	void SpawnCoily(){
		Destroy (gameObject);
		Instantiate (enemyPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.01f), Quaternion.identity) ;
	}

	void Restart()
	{
		Destroy (gameObject);

	}

}

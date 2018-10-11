using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallScript : MonoBehaviour {
	private Rigidbody2D myScriptsRigidbody2D;
	private int directionChoice;
	private int minVal = 0;
	private int maxVal = 2;
	private GameObject coilyDeathReference;
	public AudioClip bounceSound;
	private AudioSource source;

	float timeLeft = 5.0f;

	// Use this for initialization
	void Start () {
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
		coilyDeathReference = GameObject.Find("CoilyStop");
	}


	void Update() {
		GameObject reference2 = GameObject.Find("Player");
		PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();

		CoilyDeathRestart coilyDeathReference1 = coilyDeathReference.GetComponent<CoilyDeathRestart>();

		if (playerScript3.isDead == true || playerScript3.didWin == true || coilyDeathReference1.coilyDied == true) {
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


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Coily" && other.tag != "CoilyBall"  && other.tag != "Player" && other.tag != "Touched"
			&& other.tag != "Elevator1" && other.tag != "Elevator2" && other.tag != "DeathFall" && other.tag != "DeadPlayer" && other.tag != "ElevatorStop" && other.tag != "CoilyStop"  
			&& other.tag != "GreenBall" && other.tag != "SetAlive") {
			
		directionChoice = Random.Range(minVal, maxVal);

			source.PlayOneShot (bounceSound);

		if (directionChoice == 0) {
			myScriptsRigidbody2D.AddForce(Vector2.up * 16.0f);
			myScriptsRigidbody2D.AddForce(new Vector3(-0.474f, -0.702f, 1) * 7);
			CancelInvoke ();
		}

			if (directionChoice == 1) {
				myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
				myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, -0.702f, 1) * 7); 
				CancelInvoke ();
			}
		}

		if (other.tag == "DeathFall")
			Destroy (gameObject);

	}


	void Restart()
	{
		Destroy (gameObject);

	}
}

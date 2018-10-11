using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : MonoBehaviour {
	public float speed;
	Animator anim;

	private Transform target;

	private Rigidbody2D myScriptsRigidbody2D;

	private SpriteRenderer sprite;
	public int sortingOrder = 0;

	private bool jumpingRightUp = false;
	private bool jumpingLeftUp = false;

	public AudioClip deathFallSound;
	public AudioClip bounceSound;
	private AudioSource source;
	float timeLeft = 5.0f;
	GameObject reference2;
	public bool isDead = false;
	public int check = 0;
	public float timeBetweenShots = 0.55f; 
	private float timestamp;

	public Sprite leftCoily;
	public Sprite rightCoily;


	// Use this for initialization
	void Start () {
		myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
		Time.timeScale = 1;
		anim = GetComponent<Animator> ();

		if (GameObject.FindGameObjectWithTag ("Player") == null) {
			target = GameObject.FindGameObjectWithTag ("DeadPlayer").GetComponent<Transform> ();
		} else {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}

	}
	//target = GameObject.FindGameObjectWithTag ("DeadPlayer").GetComponent<Transform> ();

	void Update () {
		reference2 = GameObject.Find("Player");
		PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();
		//Debug.Log (playerScript2.isOn);

		if (playerScript3.isDead == true || playerScript3.didWin == true) {
			gameObject.GetComponent<Rigidbody2D> ().simulated = false;

			Invoke ("Restart", 2);
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

	void OnTriggerEnter2D (Collider2D other) {
		if (transform.gameObject.tag != "deadCoily") {

			if (other.tag != "Enemy" && other.tag != "Player" && other.tag != "CoilyBall"  && other.tag != "Elevator1"
				&& other.tag != "Elevator2" && other.tag != "DeadPlayer" && other.tag != "CoilyStop"  && other.tag != "GreenBall" && other.tag != "LowerBase") {
				source.PlayOneShot (bounceSound);

				if (Vector2.Distance (transform.position, target.position) >= 0) {
			
					if (target.position.x > transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp
						|| target.position.x == transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp 
						|| target.position.x > transform.position.x && target.position.y == transform.position.y && Time.time >= timestamp) {
						myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
						myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, 0.702f, 1) * 7);
						jumpingRightUp = true;
						jumpingLeftUp = false;
						timestamp = Time.time + timeBetweenShots;
						anim.SetInteger("State", 1);
						//Debug.Log ("1");

					}

					if (target.position.x < transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp) {
						myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
						myScriptsRigidbody2D.AddForce (new Vector3 (-0.474f, 0.702f, 1) * 7);
						jumpingLeftUp = true;
						jumpingRightUp = false;
						timestamp = Time.time + timeBetweenShots;
						anim.SetInteger("State", 0);

						//Debug.Log ("2");
					} 

					if (target.position.x < transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp 
						|| target.position.x == transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp
						|| target.position.x < transform.position.x && target.position.y == transform.position.y && Time.time >= timestamp) {
						myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
						myScriptsRigidbody2D.AddForce (new Vector3 (-0.474f, -0.702f, 1) * 7);
						timestamp = Time.time + timeBetweenShots;
						anim.SetInteger("State", 0);

						//Debug.Log ("3");
					}

					if (target.position.x > transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp) {
						myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
						myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, -0.702f, 1) * 7);
						timestamp = Time.time + timeBetweenShots;
						anim.SetInteger("State", 1);

						//Debug.Log ("4");

					}
				}
			}

			if (other.tag == "CoilyStop") {
				PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();
				source.PlayOneShot (deathFallSound);
				LaunchProjectile ();					
				transform.gameObject.tag = "deadCoily";
				isDead = true;
				check++;
				playerScript3.score += 500;
				playerScript3.coilyDeathPoints += 500;
			}

			if (other.tag == "LowerBase") {
				source.PlayOneShot (bounceSound);

				if (target.position.x > transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp
					|| target.position.x == transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp 
					|| target.position.x > transform.position.x && target.position.y == transform.position.y && Time.time >= timestamp) {
					myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
					myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, 0.702f, 1) * 7);
					jumpingRightUp = true;
					jumpingLeftUp = false;
					timestamp = Time.time + timeBetweenShots;
					anim.SetInteger("State", 1);
					//Debug.Log ("1");

				}

				if (target.position.x < transform.position.x && target.position.y > transform.position.y && Time.time >= timestamp) {
					myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
					myScriptsRigidbody2D.AddForce (new Vector3 (-0.474f, 0.702f, 1) * 7);
					jumpingLeftUp = true;
					jumpingRightUp = false;
					timestamp = Time.time + timeBetweenShots;
					anim.SetInteger("State", 0);

					//Debug.Log ("2");
				} 

				if (target.position.x < transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp 
					|| target.position.x == transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp
					|| target.position.x < transform.position.x && target.position.y == transform.position.y && Time.time >= timestamp) {
					myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
					myScriptsRigidbody2D.AddForce (new Vector3 (-0.474f, 0.702f, 1) * 7);
					timestamp = Time.time + timeBetweenShots;
					anim.SetInteger("State", 0);

					//Debug.Log ("3");
				}

				if (target.position.x > transform.position.x && target.position.y < transform.position.y && Time.time >= timestamp) {
					myScriptsRigidbody2D.AddForce (Vector2.up * 16.0f);
					myScriptsRigidbody2D.AddForce (new Vector3 (0.474f, 0.702f, 1) * 7);
					timestamp = Time.time + timeBetweenShots;
					anim.SetInteger("State", 1);

					//Debug.Log ("4");

				}
			
			}

			if (other.tag == "DeathFall") {
				Destroy (gameObject);
			}
		}
	}

	void LaunchProjectile()
	{
		sprite.sortingOrder = sortingOrder;

	}


	void Restart()
	{
		Destroy (gameObject);
	}
}



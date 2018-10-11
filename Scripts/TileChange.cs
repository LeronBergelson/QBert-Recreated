using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChange : MonoBehaviour {
	[SerializeField] GameObject tilePrefab;
	private int check = 0;
	GameObject reference2;
	private int num = 0;
	private bool didTouch = false;
	public Sprite rightJumpDown;
	public Sprite leftJumpUp;
	public Sprite leftJumpDown;
	public Sprite rightJumpUp;

	void OnTriggerEnter2D (Collider2D other) {

		if(other.tag == "Player"){

			GameObject thePlayer = GameObject.Find("Player");
			PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement>();
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;		
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.0695f, this.transform.position.z);
			if(check == 0){
			Instantiate (tilePrefab, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity) ;
			}
			check++;
			didTouch = true;

			if(playerScript.didLeftJumpDown){
				other.GetComponent<SpriteRenderer>().sprite = leftJumpDown;

			}
			if(playerScript.didRightJumpDown){
				other.GetComponent<SpriteRenderer>().sprite = rightJumpDown;

			}
			if(playerScript.didLeftJumpUp){
				other.GetComponent<SpriteRenderer>().sprite = leftJumpUp;

			}
			if(playerScript.didRightJumpUp){
				other.GetComponent<SpriteRenderer>().sprite = rightJumpUp;

			}
	}

		if (other.tag == "Enemy") {
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}

		if (other.tag == "Coily") {
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}


		if (other.tag == "CoilyBall") {
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}

		if (other.tag == "GreenBall") {
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}
	}

	void Update(){
		reference2 = GameObject.Find("Player");
		PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();
					
		if (check == 1) {
			playerScript3.score += check * 25;
			check++;
		}
		}


	//void OnTriggerStay2D (Collider2D other) {
		
}

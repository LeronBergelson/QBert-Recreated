using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject coilyBallPrefab;
	[SerializeField] GameObject greenBallPrefab;

	public float time;
	public float coilyTime;
	public float repeatRate = 10;
	public float greenBallTime;


	void Start()
	{
		InvokeRepeating("LaunchProjectile", time, repeatRate);

		
	}

	void LaunchProjectile(){
		time += repeatRate;


		if(time != coilyTime && time != greenBallTime)
			Instantiate (enemyPrefab, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity) ;

		if(time == coilyTime)
			Instantiate (coilyBallPrefab, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity) ;

		if(time == greenBallTime)
			Instantiate (greenBallPrefab, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity) ;



	}

}


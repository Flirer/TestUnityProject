using UnityEngine;
using System.Collections;

public class spawnerBehavior : MonoBehaviour {
	public Object targetToSpawn;
	public float minTimeBetweenSpawns;
	public float maxTimeBetweenSpawns;
	public float nextSpawnTime;
	public bool spawnIsReady;
	private Vector3 spawnPos;

	//private bool timerIsRunning;
	private Timer spawnTimer = new Timer();

	// Use this for initialization
	void Start () {
		spawnIsReady = true;

		nextSpawnTime = Random.Range (minTimeBetweenSpawns, maxTimeBetweenSpawns);

		spawnPos = transform.position;
		spawnPos.y += 0.6f;

		spawnTimer.finish += spawnNewTarget;


	}
	
	// Update is called once per frame
	void Update () {
		/*if (Timer()) {
			spawnNewTarget();
		}*/
		if (spawnIsReady) {
			nextSpawnTime = Random.Range (minTimeBetweenSpawns, maxTimeBetweenSpawns);
			//timerIsRunning = true;
			spawnIsReady = false;

			spawnTimer.Set(nextSpawnTime);
			spawnTimer.Go ();
			Debug.Log ("Next spawn time is set to"+nextSpawnTime);
		}
	}

	void spawnNewTarget() {
		GameObject target =  Instantiate(targetToSpawn, spawnPos, transform.rotation) as GameObject;
		targetBehavior script = target.GetComponent<targetBehavior> ();

		script.spawner = this;

	}

	/*bool Timer () {
		if (timerIsRunning) {
			nextSpawnTime = nextSpawnTime - Time.deltaTime;
			//Debug.Log(nextSpawnTime);
			if (nextSpawnTime <= 0) {
				timerIsRunning = false;
				return true;
			}
			return false;
		}
		return false;
	}*/


}

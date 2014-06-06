using UnityEngine;
using System.Collections;

public class targetBehavior : MonoBehaviour {
	public Material stage2;
	public Material stage3;
	private float timer;
	private int stage;
	private float timerLength = 2;
	public spawnerBehavior spawner;

	// Use this for initialization
	void Start () {
		stage = 1;
		timer = timerLength;

	}
	
	// Update is called once per frame
	void Update () {
		if (Timer ()) {
			if (stage == 1) {
				this.renderer.material = stage2;
				stage = 2;
				return;
			}
			if (stage == 2) {
				this.renderer.material = stage3;
				stage = 3;
				return;
			}
			if (stage ==3) {
				Destroy(this.gameObject);
				Debug.Log("minus score");
				spawner.spawnIsReady = true;
			}

		}
	}

	bool Timer () {
		timer = timer - Time.deltaTime;


		if (timer <= 0) {
			timer = timerLength;
			return true;

		}
		return false;
	}

	void OnCollisionEnter2D (Collision2D other) {
		
		if (other.gameObject.tag == "Projectile") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);

			spawner.spawnIsReady = true;


		}
	}
}

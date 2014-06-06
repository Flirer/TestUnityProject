using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {
	public float xForce;
	public float yForce;
	public Vector2 mouseVector;
	public bool ready;
	public int numberOfTouchesMax;
	private int numberOfTouchesMade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ready) {

			rigidbody2D.AddForce(mouseVector);
			ready = false;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		numberOfTouchesMade++;
		if (numberOfTouchesMade == numberOfTouchesMax) {
			Destroy(this.gameObject);
		}
	}


}

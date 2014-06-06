using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {
	public float moveSpeed;
	public int numberOfTouches;
	public Object ballToThrow;
	public GameObject crosshair;
	private float yForce;
	private float xForce;
	private float mouseX;
	private float mouseY;
	private bool dragging;
	private Vector2 mouseEnd;

	// Use this for initialization
	void Start () {
		crosshair.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (dragging) {

			float cursorX = Input.mousePosition.x;
			float cursorY = Input.mousePosition.y;

			//X
			if (mouseX > cursorX) {
				xForce = mouseX - cursorX;
			} 
			if (mouseX < cursorX) {
				xForce = (cursorX - mouseX)*(-1);
			}
			if (mouseX == cursorX) {
				xForce = 0;
			}


			//Y
			if (mouseY > cursorY) {
				yForce = mouseY - cursorY;
			} 
			if (mouseY < cursorY) {
				yForce = (cursorY - mouseY)*(-1);
			}
			if (mouseY == cursorY) {
				yForce = 0;
			}

			updateCrosshair();

		}

	}

	void OnMouseDown()
	{
		// this object was clicked - do something

		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;

		Debug.Log("Mouse end pos:" + mouseX);

		dragging = true;
		crosshair.renderer.enabled = true;
	}

	void OnMouseUp() {

		dragging = false;

		mouseEnd = new Vector2 (xForce*moveSpeed, yForce*moveSpeed);

		GameObject ball =  Instantiate(ballToThrow, transform.position, transform.rotation) as GameObject;
		ballScript script = ball.GetComponent<ballScript> ();



		script.mouseVector = mouseEnd;
		script.numberOfTouchesMax = numberOfTouches;
		script.ready = true;


		xForce = 0f;
		yForce = 0f;

		crosshair.renderer.enabled = false;
	}

	void updateCrosshair () {
		Vector3 crosshardPosition = new Vector3 ((xForce)/100+1.7f, (yForce)/100 -0.4f , 0);

		//Debug.Log("Crosshair pos:" + crosshardPosition);


		crosshair.transform.position = (crosshardPosition);
	}

}

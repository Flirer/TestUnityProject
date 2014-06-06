using UnityEngine;
using System.Collections;

public class  Timer {
	public float iniTime = 2;
	public float time;
	public bool running = false;

	
	public delegate void Finish();
	public event Finish finish;


	public Timer () {
		TimerBase.timerTick += Update;
	}

	public Timer (float n) {
		Set (n);
		TimerBase.timerTick += Update;
	}

	void Update () {
		if (time > 0) {
			time -= 0.02f;
			
			if (time < 0) {
				finish();
			}

		}
	}

	public void Set(float n) {
		iniTime = n;
	}

	public void Go () {
		if (!running) {
			time = iniTime;
			running = true;
		} else {
			Reset(true);
		}

	}

	public void Reset () {
		time = iniTime;
	}

	public void Reset (bool run) {
		time = iniTime;
		if (run) {
			Resume();
		}
	}

	public void Reset (bool run, float n) {
		iniTime = n;
		time = iniTime;
		if (run) {
			Resume();
		}
	}

	public void Pause () {
		running = false;
	}

	public void Resume () {
		running = true;
	}




}

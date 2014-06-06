using UnityEngine;
using System.Collections;

public class TimerBase : MonoBehaviour {

	public delegate void TimerTick();
	public static event TimerTick timerTick;
	
	void FixedUpdate() {
		if (timerTick != null) {
			timerTick ();

		}
	}
}

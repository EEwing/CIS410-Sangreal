using UnityEngine;
using System.Collections;
using System;

public class MovingPlatformHorizontal : MonoBehaviour {

	private float startx;
	private bool right;
	public float distance;
	public float speed;

	void Start () {
		startx = transform.position.x;
		right = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		if (right == true) {
			Vector3 toTranslate = new Vector3 (speed * Time.deltaTime, 0f, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.x >= startx + distance) {
			right = false;
		}
		if (right == false) {
			Vector3 toTranslate = new Vector3 (-speed * Time.deltaTime, 0f, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.x <= startx - distance) {
			right = true;
		}


	}
}

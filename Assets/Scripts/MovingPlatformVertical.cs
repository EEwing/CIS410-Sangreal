using UnityEngine;
using System.Collections;
using System;

public class MovingPlatformVertical : MonoBehaviour {

	private float startv;
	private bool up;
	public float distance;
	public float speed;
	public bool moveUpFromStart;
	public bool moveDownFromStart;
	private float maxY;
	private float minY;

	void Start () {
		startv = transform.position.y;
		maxY = startv + distance;
		minY = startv - distance;
		up = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float top, bottom;
		top = moveUpFromStart ? maxY : startv;
		bottom = moveDownFromStart ? minY : startv;
		if (up == true) {
			Vector3 toTranslate = new Vector3 (0f, speed * Time.deltaTime, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.y >= top) {
			up = false;
		}
		if (up == false) {
			Vector3 toTranslate = new Vector3 (0f, -speed * Time.deltaTime, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.y <= bottom) {
			up = true;
		}


	}
}

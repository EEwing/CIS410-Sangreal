using UnityEngine;
using System.Collections;
using System;

public class MovingPlatformVertical : MonoBehaviour {

	private float startv;
	private bool up;
	public float distance;
	public float speed;

	void Start () {
		startv = transform.position.y;
		up = true;
	}

	// Update is called once per frame
	void Update () {


		if (up == true) {
			Vector3 toTranslate = new Vector3 (0f, speed * Time.deltaTime, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.y >= startv + distance) {
			up = false;
		}
		if (up == false) {
			Vector3 toTranslate = new Vector3 (0f, -speed * Time.deltaTime, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.y <= startv) {
			up = true;
		}


	}
}

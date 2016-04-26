using UnityEngine;
using System.Collections;
using System;

public class MovingPlatformHorizontal : MonoBehaviour {

	private float startx;
	private bool right;
	public float distance;
	public float speed;
	public bool moveRightFromStart;
	public bool moveLeftFromStart;
	private float minX;
	private float maxX;

	void Start () {
		startx = transform.position.x;
		minX = startx - distance;
		maxX = startx + distance;
		right = true;
	}
	
	// Update is called once per frame
<<<<<<< HEAD
	void FixedUpdate () {
		
=======
	void Update () {
		float r, l;

		r = moveRightFromStart ? maxX : startx;
		l = moveLeftFromStart ? minX : startx;
>>>>>>> origin/master

		if (right == true) {
			Vector3 toTranslate = new Vector3 (speed * Time.deltaTime, 0f, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.x >= r) {
			right = false;
		}
		if (right == false) {
			Vector3 toTranslate = new Vector3 (-speed * Time.deltaTime, 0f, 0f);
			transform.Translate (toTranslate);
		}
		//once we hit a certain distance turn around
		if (transform.position.x <= l) {
			right = true;
		}


	}
}

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

	void FixedUpdate () {
		

		float r, l;

		r = moveRightFromStart ? maxX : startx;
		l = moveLeftFromStart ? minX : startx;


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
	void OnCollisionEnter(Collision playerObject)
	{
		Debug.Log ("enter moving platform");
		if(playerObject.gameObject.name.Contains("Player"))
		{
			playerObject.transform.parent = gameObject.transform;
		}
	}
	int i = 0;
	void OnCollisionStay(Collision playerObject)
	{
		Debug.Log ("stay" + i++);
		if(playerObject.transform.position.y >= transform.position.y)
		{
			playerObject.transform.parent = gameObject.transform;
		}
		else
		{
			playerObject.transform.parent=null;
		}
	}
	void OnCollisionExit(Collision playerObject)
	{
		Debug.Log ("EXIT");
		if(playerObject.gameObject.name.Contains("Player"))
		{
			playerObject.transform.parent=null;
		}
	}
}

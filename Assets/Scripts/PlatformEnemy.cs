using UnityEngine;
using System.Collections;

public class PlatformEnemy : Damageable {

	public GameObject player;
	public Animator animator;
	public int engageDistance;
	private int facing = -1;
	private float initialX;
	public float guardDistance;
	Vector3 toTranslate;
	bool myanimationisplaying = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		initialX = transform.position.x;
		animator.Play("March");
	}
	
	// Update is called once per frame
	void Update () {
		myanimationisplaying = true;
		if (myanimationisplaying == true)
		{
			//animator.ResetTrigger("stop");

		}
		else
		{
			//  Debug.Log("Triggering stop");
			//animator.SetTrigger("stop");
		}

	}

	void FixedUpdate(){
		Transform parent = transform.parent;
		transform.parent = null;
		//lets move the character back and forth
		if (facing > 0) {
			//Debug.Log ("Moving to the right");
			GetComponent<Rigidbody> ().transform.Translate (facing * speed * Time.deltaTime, 0f, 0f, Space.World);
			//toTranslate = new Vector3 (facing * speed * Time.deltaTime, 0f, 0f);
		} else {
			//Debug.Log ("Moving to the left");
			GetComponent<Rigidbody> ().transform.Translate (facing * speed * Time.deltaTime, 0f, 0f, Space.World);
			//toTranslate = new Vector3 (facing * speed * Time.deltaTime, 0f, 0f);
		}

		if (transform.position.x < initialX - guardDistance) {
			facing = 1;

		}

		if (transform.position.x > initialX + guardDistance) {
			facing = -1;

		}
		if (facing < 0) {
			transform.rotation = Quaternion.Euler (0, 90, 0);
		}
		if (facing > 0) {
			transform.rotation = Quaternion.Euler (0, -90, 0);
		}

		transform.parent = parent;
	}


	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
			Damage (20);
		} else if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Damageable> ().Damage (10);
		}
	}
}

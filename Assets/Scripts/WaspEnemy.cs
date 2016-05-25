
using UnityEngine;
using System.Collections;

public class WaspEnemy : Damageable {

	public GameObject player;
	public int engageDistance;

	public float patrolDistance;
	public AudioClip moveSound1;
	public AudioSource efxSource;
	private bool buzzing = false;

	private float startx;
	private bool right;

	private float elapsedTime;
	private bool patrol;
	private float leftX;
	private float rightX;



	void Start () {
		startx = transform.position.x;
		leftX = startx - patrolDistance;
		rightX = startx + patrolDistance;
		right = true;
		patrol = true;
		player = GameObject.Find("Player");


	}


	// Update is called once per frame
	void Update () {

		//transform.LookAt (player.transform.position); 
		if (Vector3.Distance (player.transform.position, transform.position) < engageDistance) {
			patrol = false;
			transform.LookAt (player.transform.position); 
			//transform.position = player.transform.position;
			transform.position += transform.forward * speed * Time.deltaTime;

			if (buzzing == false) {
				efxSource.clip = moveSound1;
				efxSource.Play ();
				buzzing = true;
			}
		} else {

			efxSource.clip = moveSound1;
			efxSource.Stop ();
			buzzing = false;
			patrol = true;
			startx = transform.position.x;
			leftX = startx - patrolDistance;
			rightX = startx + patrolDistance;



		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
			Damage(5);
		} 
	}
	void FixedUpdate () {

		float r, l;

		r = rightX;
		l = leftX;
		elapsedTime += Time.deltaTime;



		if (patrol == true) {
			if (elapsedTime > speed) {
				elapsedTime = 0;
				right = !right;

				transform.Rotate (new Vector3 (0, 180, 0));
			}
			Vector3 toTranslate = new Vector3 (0f, 0f, speed * Time.deltaTime);
			transform.Translate (toTranslate);


		}
	}
	void OnCollisionEnter(Collision playerObject)
	{
		//Debug.Log ("enter moving platform");
		if(!playerObject.gameObject.name.Contains("Player"))
		{
			//playerObject.transform.parent = gameObject.transform;
			right = !right;

			transform.Rotate (new Vector3 (0, 180, 0));
		}
	}

}

using UnityEngine;
using System.Collections;

public class WaspEnemy : Damageable {

	public GameObject player;
	public int engageDistance;
	public AudioClip moveSound1;
	public AudioSource efxSource;
	private bool buzzing = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position); 
		if (Vector3.Distance (player.transform.position, transform.position) < engageDistance) {
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
		}

	}
	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
            Damage(5);
		} 
	}
}

using UnityEngine;
using System.Collections;

public class PlatformEnemy : Damageable {

	public GameObject player; 
	public int engageDistance;

	// Use this for initialization
	void Start () {
			player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < engageDistance) {
			transform.LookAt (player.transform.position); 
			transform.position += transform.forward * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
            Damage(5);
		} 
	}
}

using UnityEngine;
using System.Collections;

public class PlatformEnemy : MonoBehaviour {

	public GameObject player; 
	public int moveSpeed;
	public int health;
	public int engageDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) < engageDistance) {
			transform.LookAt (player.transform.position); 
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
			health--;
			if (health == 0) {
				Destroy (gameObject);
			}
		} 
	}
}

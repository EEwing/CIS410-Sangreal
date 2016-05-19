using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcherBehave : Damageable {

	public GameObject player; 
	public int engageDistance;
	public GameObject knifePrefab;

	private float elapsedTime;
	private int facing = 1;

	// Use this for initialization
	//void Start () {
	//
	//}
	
	// Update is called once per frame
	void Update () {
		
		elapsedTime += Time.deltaTime;
		if (Vector3.Distance (player.transform.position, transform.position) < engageDistance) {
			transform.LookAt (player.transform.position); 

			if (elapsedTime > 0.5) {
				elapsedTime = 0;
				GameObject knife = (GameObject)Instantiate (knifePrefab, transform.position + new Vector3 (1, 1, 0), transform.rotation);
				knife.GetComponent<KnifeManager>().facing = facing;
				knife.GetComponent<KnifeManager>().setFacing(facing);
				Physics.IgnoreCollision (knife.GetComponent<Collider> (), GetComponent<Collider> ());
				knife.GetComponent<Rigidbody> ().AddForce (Vector3.right * 750 * facing);
			}
			//transform.position += transform.forward * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Collided with "+other.gameObject.name);
		if (other.gameObject.tag == "Weapon") {
            Damage(5);
		} 
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcherBehave : Damageable {

	public GameObject player; 
	public int engageDistance;
	public GameObject arrowPrefab;

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

			if (elapsedTime > 2) {
				elapsedTime = 0;
				GameObject arrow = (GameObject)Instantiate (arrowPrefab, transform.position + new Vector3 (1, 1, 0), transform.rotation);
				arrow.GetComponent<KnifeManager>().facing = facing;
				arrow.GetComponent<KnifeManager>().setFacing(facing);
				Physics.IgnoreCollision (arrow.GetComponent<Collider> (), GetComponent<Collider> ());
				arrow.GetComponent<Rigidbody> ().AddForce (Vector3.right * 600 * facing);
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

	void FixedUpdate () {
		if (Input.GetAxis ("Horizontal") > 0) {
			facing = -1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			facing = 1;
		}
		Vector3 toTranslate = new Vector3 (Input.GetAxis ("Horizontal") * Time.deltaTime, 0f, 0f);
		//GetComponent<Rigidbody> ().transform.Translate (toTranslate);

	}
}

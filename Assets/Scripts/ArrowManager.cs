using UnityEngine;
using System.Collections;

public class ArrowManager : MonoBehaviour {
	private int i;
	public int facing;
	private float gravityFactor = 0.25f;
	// Use this for initialization
	void Start () {
		i = 0;
		transform.Rotate (new Vector3 (0, 0, 30));
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (-transform.forward);
	}

	void FixedUpdate(){
		i++;
		if (i > 300) {
			Destroy (gameObject);
		}
		//transform.Rotate (new Vector3 (0, 0, -30 * facing));
		//GetComponent<Rigidbody>().AddForce(gravityFactor * Physics.gravity);
	}

	void OnCollisionEnter(Collision other) {
		Destroy (gameObject);
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<Damageable>().Damage(1);
		}
	}
}

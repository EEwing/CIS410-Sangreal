using UnityEngine;
using System.Collections;

public class KnifeManager : MonoBehaviour {
	private int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		i++;
		if (i > 300) {
			Destroy (gameObject);
		}
		transform.Rotate (new Vector3 (0, 0, -20));
	}

	void OnCollisionEnter(Collision other) {
		Destroy (gameObject);
	}
}
